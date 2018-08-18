ALTER TABLE public."Module"
    ADD COLUMN "Creator" character varying(50);
	
	
ALTER TABLE public."Module"
    ADD COLUMN "Modifier" character varying(50);


CREATE TABLE public."Role"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "RoleCode" character varying(2) NOT NULL,
    "RoleName" character varying(100) NOT NULL,
    "IsActive" numeric(2) DEFAULT 1,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Role_Uk1" UNIQUE ("RoleCode")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Role"
    OWNER to postgres;
	
	
CREATE SEQUENCE public."RoleSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 20;

ALTER SEQUENCE public."RoleSeq"
    OWNER TO postgres;