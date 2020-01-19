package org.modmappings.mmms.api.services.core;

import org.modmappings.mmms.api.model.core.MappingTypeDTO;
import org.modmappings.mmms.api.services.utils.exceptions.EntryNotFoundException;
import org.modmappings.mmms.api.services.utils.exceptions.InsertionFailureDueToDuplicationException;
import org.modmappings.mmms.api.services.utils.exceptions.NoEntriesFoundException;
import org.modmappings.mmms.api.services.utils.user.UserService;
import org.modmappings.mmms.repository.model.core.MappingTypeDMO;
import org.modmappings.mmms.repository.repositories.core.IMappingTypeRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Component;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

import java.security.Principal;
import java.util.UUID;

/**
 * Business layer service which handles the interactions of the API with the DataLayer.
 * <p>
 * This services validates data as well as converts between the API models as well as the data models.
 * <p>
 * This services however does not validate if a given user is authorized to execute a given action.
 * It only validates the interaction from a data perspective.
 * <p>
 * The caller is to make sure that any interaction with this service is authorized, for example by checking
 * against a role that a user needs to have.
 */
@Component
public class MappingTypeService {

    private final Logger logger = LoggerFactory.getLogger(MappingTypeService.class);
    private final IMappingTypeRepository repository;
    private final UserService userService;

    public MappingTypeService(final IMappingTypeRepository repository, final UserService userService) {
        this.repository = repository;
        this.userService = userService;
    }

    /**
     * Looks up a mapping type with a given id.
     *
     * @param id The id to look the mapping type up for.
     * @return A {@link Mono} containing the requested mapping type or a errored {@link Mono} that indicates a failure.
     */
    public Mono<MappingTypeDTO> getBy(UUID id) {
        return repository.findById(id)
                .doFirst(() -> logger.debug("Looking up a mapping type by id: {}", id))
                .filter(MappingTypeDMO::isVisible)
                .map(this::toDTO)
                .doOnNext(dto -> logger.debug("Found mapping type: {} with id: {}", dto.getName(), dto.getId()))
                .switchIfEmpty(Mono.error(new EntryNotFoundException(id, "MappingType")));
    }

    /**
     * Looks up multiple mapping types.
     * The returned order is newest to oldest.
     *
     * @param page The 0-based page index used during pagination logic.
     * @param size The maximum amount of items on a given page.
     * @return A {@link Flux} with the mapping types, or an errored {@link Flux} that indicates a failure.
     */
    public Flux<MappingTypeDTO> getAll(int page, int size) {
        return repository.findAll()
                .doFirst(() -> logger.debug("Looking up mapping types."))
                .skip(page * size)
                .limitRequest(size)
                .filter(MappingTypeDMO::isVisible)
                .map(this::toDTO)
                .doOnNext(dto -> logger.debug("Found mapping type: {} with id: {}", dto.getName(), dto.getId()))
                .switchIfEmpty(Flux.error(new NoEntriesFoundException("MappingType")));
    }

    /**
     * Determines the amount of mapping types that exist in the database.
     *
     * @return A {@link Mono} that indicates the amount of mapping types in the database.
     */
    public Mono<Long> count() {
        //TODO: Implement custom count that takes visibility into account.
        return repository
                .count()
                .doFirst(() -> logger.debug("Determining the available amount of mapping types"))
                .doOnNext((cnt) -> logger.debug("There are {} mapping types available.", cnt));
    }

    /**
     * Looks up multiple mapping types, that match the search criteria.
     * The returned order is newest to oldest.
     *
     * @param nameRegex The regular expression against which the name of the mapping type is matched.
     * @param editable Indicates if editable mapping types need to be included, null indicates do not care.
     * @param page The 0-based page index used during pagination logic.
     * @param size The maximum amount of items on a given page.
     * @return A {@link Flux} with the mapping types, or an errored {@link Flux} that indicates a failure.
     */
    public Flux<MappingTypeDTO> search(String nameRegex, Boolean editable, int page, int size) {
        return repository.findAllFor(nameRegex, editable)
                .doFirst(() -> logger.debug("Looking up mapping types in search mode. Using parameters: {}, {}", nameRegex, editable))
                .skip(page * size)
                .limitRequest(size)
                .filter(MappingTypeDMO::isVisible)
                .map(this::toDTO)
                .doOnNext(dto -> logger.debug("Found mapping type: {} with id: {}", dto.getName(), dto.getId()))
                .switchIfEmpty(Flux.error(new NoEntriesFoundException("MappingType")));
    }

    /**
     * Counts the mapping types, that match the search criteria.
     *
     * @param nameRegex The regular expression against which the name of the mapping type is matched.
     * @param editable Indicates if editable mapping types need to be included, null indicates do not care.
     * @return A {@link Flux} with the mapping types, or an errored {@link Flux} that indicates a failure.
     */
    public Mono<Long> countForSearch(String nameRegex, Boolean editable) {
        return repository.findAllFor(nameRegex, editable)
                .doFirst(() -> logger.debug("Counting mapping types in search mode: {}, {}", nameRegex, editable))
                .filter(MappingTypeDMO::isVisible)
                .count()
                .doOnNext(cnt -> logger.debug("Found mapping types: {}", cnt));
    }

    /**
     * Deletes a given mapping type if it exists.
     *
     * @param id The id of the mapping type that should be deleted.
     * @return A {@link Mono} indicating success or failure.
     */
    public Mono<Void> deleteBy(UUID id, Principal principal) {
        //TODO: Handle a delete attempt on an invisible mapping type.
        return repository.deleteById(id)
                .doFirst(() -> userService.warn(logger, principal, String.format("Deleting mapping type with id: %s", id)))
                .doOnNext(aVoid -> userService.warn(logger, principal, String.format("Deleted mapping type with id: %s", id)));
    }

    /**
     * Creates a new mapping type from a DTO and saves it in the repository.
     *
     * @param newMappingType The dto to create a new mapping type from.
     * @return A {@link Mono} that indicates success or failure.
     */
    public Mono<MappingTypeDTO> create(MappingTypeDTO newMappingType, Principal principal) {
        return Mono.just(newMappingType)
                .doFirst(() -> userService.warn(logger, principal, String.format("Creating new mapping type: %s", newMappingType.getName())))
                .map(dto -> this.toNewDMO(dto, principal))
                .flatMap(repository::save)
                .map(this::toDTO)
                .doOnNext(dmo -> userService.warn(logger, principal, String.format("Created new mapping type: %s with id: %s", dmo.getName(), dmo.getId())))
                .onErrorResume(throwable -> throwable.getMessage().contains("duplicate key value violates unique constraint \"IX_game_version_name\""), dive -> Mono.error(new InsertionFailureDueToDuplicationException("MappingType", "Name")));
    }

    /**
     * Updates an existing mapping type with the data in the dto and saves it in the repo.
     *
     * @param newMappingType The dto to update the data in the dmo with.
     * @return A {@link Mono} that indicates success or failure.
     */
    public Mono<MappingTypeDTO> update(UUID idToUpdate, MappingTypeDTO newMappingType, Principal principal) {
        //TODO: Handle an update attempt to an invisible mapping type.
        return repository.findById(idToUpdate)
                .doFirst(() -> userService.warn(logger, principal, String.format("Updating mapping type: %s", idToUpdate)))
                .switchIfEmpty(Mono.error(new EntryNotFoundException(newMappingType.getId(), "MappingType")))
                .doOnNext(dmo -> userService.warn(logger, principal, String.format("Updating db mapping type: %s with id: %s, and data: %s", dmo.getName(), dmo.getId(), newMappingType)))
                .filter(MappingTypeDMO::isVisible)
                .doOnNext(dmo -> this.updateDMO(newMappingType, dmo)) //We use doOnNext here since this maps straight into the existing dmo that we just pulled from the DB to update.
                .doOnNext(dmo -> userService.warn(logger, principal, String.format("Updated db mapping type to: %s", dmo)))
                .flatMap(dmo -> repository.save(dmo)
                        .onErrorResume(throwable -> throwable.getMessage().contains("duplicate key value violates unique constraint \"IX_game_version_name\""), dive -> Mono.error(new InsertionFailureDueToDuplicationException("MappingType", "Name"))))
                .map(this::toDTO)
                .doOnNext(dto -> userService.warn(logger, principal, String.format("Updated mapping type: %s with id: %s, to data: %s", dto.getName(), dto.getId(), dto)));
    }

    private MappingTypeDTO toDTO(MappingTypeDMO dmo) {
        return new MappingTypeDTO(
                dmo.getId(),
                dmo.getCreatedBy(),
                dmo.getCreatedOn(),
                dmo.getName(),
                dmo.isEditable()
        );
    }

    private MappingTypeDMO toNewDMO(MappingTypeDTO dto, Principal principal) {
        return new MappingTypeDMO(
                userService.getCurrentUserId(principal),
                dto.getName(),
                true,
                dto.isEditable()
        );
    }

    private void updateDMO(MappingTypeDTO dto, MappingTypeDMO dmo) {
        dmo.setName(dto.getName());
        dmo.setEditable(dmo.isEditable());
    }
}
