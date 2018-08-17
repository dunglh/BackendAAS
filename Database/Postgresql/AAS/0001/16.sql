CREATE TABLE public."ModuleRole"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" numeric(2) DEFAULT 1,
    "ModuleId" numeric(19) NOT NULL,
    "RoleId" numeric(19) NOT NULL,
    "IsAllowCreate" numeric(2),
    "IsAllowUpdate" numeric(2),
    "IsAllowDelete" numeric(2),
    PRIMARY KEY ("Id"),
    CONSTRAINT "ModuleRole_Uk1" UNIQUE ("ModuleId", "RoleId"),
    CONSTRAINT "ModuleRole_Fk1" FOREIGN KEY ("ModuleId")
        REFERENCES public."Module" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "ModuleRole_Fk2" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."ModuleRole"
    OWNER to postgres;
	
	
CREATE SEQUENCE public."ModuleRoleSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 99999999999999999999
    CACHE 20;

ALTER SEQUENCE public."ModuleRoleSeq"
    OWNER TO postgres;