CREATE TABLE public."UserRole"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" numeric(2) DEFAULT 1,
    "UserId" numeric(19) NOT NULL,
    "RoleId" numeric(19) NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "UserRole_Fk1" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "UserRole_Fk2" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."UserRole"
    OWNER to postgres;
	
	
CREATE SEQUENCE public."UserRoleSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 99999999999999999999
    CACHE 20;

ALTER SEQUENCE public."UserRoleSeq"
    OWNER TO postgres;