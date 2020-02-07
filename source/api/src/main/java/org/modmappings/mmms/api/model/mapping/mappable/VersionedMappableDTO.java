package org.modmappings.mmms.api.model.mapping.mappable;

import io.swagger.v3.oas.annotations.media.Schema;
import org.modmappings.mmms.repository.model.mapping.mappable.VisibilityDMO;
import org.springframework.data.annotation.Id;
import org.springframework.data.annotation.PersistenceConstructor;
import org.springframework.data.relational.core.mapping.Table;

import java.sql.Timestamp;
import java.time.Instant;
import java.util.List;
import java.util.UUID;

/**
 * This represents a single mappable in a given version of the game.
 * This table contains also all metadata related to a given type of mappable.
 *
 * This means that not all fields will be populated with data, regardless of mappable type.
 * EG, a package has no visibility, so it will be populated with NOT_APPLICABLE, however it also has no type as such that field will be null.
 *
 * See the static factory methods in this class for the fields that are populated depending on what type of mappable this represents.
 */
@Schema(name="VersionedMappable", description = "Represents a single piece of the sourcecode whose name can be remapped in a given version of the game.")
public class VersionedMappableDTO {

    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the versioned mappable.")
    private UUID id;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the user who created the versioned mappable.")
    private UUID createdBy;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The moment the versioned mappable was created.")
    private Timestamp createdOn;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the game versioned in which this versioned mappable exists.")
    private UUID gameVersionId;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the mappable which is represented by this versioned mappable in the game version.")
    private UUID mappableId;

    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the package this versioned mappable resides in. Might be null if the mappable this versioned mappable represents is not representing a class or package.")
    private UUID parentPackageId;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the class this versioned mappable resides in. Might be null if the mappable this versioned mappable represents is not representing a method or field.")
    private UUID parentClassId;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The id of the method this versioned mappable resides in. Might be null if the mappable this versioned mappable represents is not representing a parameter.")
    private UUID parentMethodId;

    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The visibility of the versioned mappable. If the visibility is not applicable to the type of mappable that this versioned mappable represents then NOT_APPLICABLE will be the value of this property.")
    private VisibilityDTO visibility;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "Indicates if this versioned mappable is static. If this versioned mappable represents a mappable of which the type can not be static this will be always false.")
    private boolean isStatic;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "Indicates the type the field. This type is in an obfuscated form and any client will need to parse the type and convert it itself into human readable language, by requesting it in the mapping type it wants to display. This field will contain an empty string if the type of mappable that this versioned mappable represents is not a field or parameter.")
    private String type;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "The descriptor that describes (ha) this versioned mappable. As with the type this descriptor is a raw obfuscated data entry. If the client wants to display this to a human in readable form he will need to parse this descriptor himself and request the human readable form of the mapping in the mapping type he wishes to display. This field will contain an empty string when the type of mappable that this versioned mappable represents is not a method.")
    private String descriptor;

    @Schema(description = "A list of all mapping types for which no changes can be made via proposals. Only changes can be made via directly committing a mapping.")
    private List<UUID> lockedIn;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "A list of ids of versioned mappables that represent the super types of the versioned mappable if this represents a class. If this is not a class, then this field will be null. If this is a class and the field is empty then no super types are known.")
    private List<UUID> superTypes;
    @Schema(accessMode = Schema.AccessMode.READ_ONLY, description = "A list of ids of versioned mappables that represent the sub types of the versioned mappables if this represents a class. If this is not a class, then this field will be null. If this is a class and the field is empty then no sub types are known.")
    private List<UUID> subTypes;

    public VersionedMappableDTO(final UUID id, final UUID createdBy, final Timestamp createdOn, final UUID gameVersionId, final UUID mappableId, final UUID parentPackageId, final UUID parentClassId, final UUID parentMethodId, final VisibilityDTO visibility, final boolean isStatic, final String type, final String descriptor, final List<UUID> lockedIn, final List<UUID> superTypes, final List<UUID> subTypes) {
        this.id = id;
        this.createdBy = createdBy;
        this.createdOn = createdOn;
        this.gameVersionId = gameVersionId;
        this.mappableId = mappableId;
        this.parentPackageId = parentPackageId;
        this.parentClassId = parentClassId;
        this.parentMethodId = parentMethodId;
        this.visibility = visibility;
        this.isStatic = isStatic;
        this.type = type;
        this.descriptor = descriptor;
        this.lockedIn = lockedIn;
        this.superTypes = superTypes;
        this.subTypes = subTypes;
    }

    public VersionedMappableDTO() {
    }

    public UUID getId() {
        return id;
    }

    public UUID getCreatedBy() {
        return createdBy;
    }

    public Timestamp getCreatedOn() {
        return createdOn;
    }

    public UUID getGameVersionId() {
        return gameVersionId;
    }

    public UUID getMappableId() {
        return mappableId;
    }

    public UUID getParentPackageId() {
        return parentPackageId;
    }

    public UUID getParentClassId() {
        return parentClassId;
    }

    public UUID getParentMethodId() {
        return parentMethodId;
    }

    public VisibilityDTO getVisibility() {
        return visibility;
    }

    public boolean isStatic() {
        return isStatic;
    }

    public String getType() {
        return type;
    }

    public String getDescriptor() {
        return descriptor;
    }

    public List<UUID> getLockedIn() {
        return lockedIn;
    }

    public List<UUID> getSuperTypes() {
        return superTypes;
    }

    public List<UUID> getSubTypes() {
        return subTypes;
    }
}