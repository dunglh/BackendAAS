CREATE TABLE public."ApplicationRole"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" numeric(2) DEFAULT 1,
    "ApplicationId" numeric(19),
    "RoleId" numeric(19),
    PRIMARY KEY ("Id", "ApplicationId", "RoleId"),
    CONSTRAINT "ApplicationRole_Fk1" FOREIGN KEY ("ApplicationId")
        REFERENCES public."Application" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "ApplicationRole_Fk2" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ApplicationRole"
    OWNER to postgres;
	
	
	
CREATE SEQUENCE public."ApplicationRoleSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 20;

ALTER SEQUENCE public."ApplicationRoleSeq"
    OWNER TO postgres;