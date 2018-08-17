CREATE TABLE public."Module"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "IsActive" numeric(2) DEFAULT 1,
    "ModuleCode" character varying(10) NOT NULL,
    "ModuleName" character varying(500) NOT NULL,
    "ApplicationId" numeric(19) NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Module_Uk1" UNIQUE ("ModuleCode", "ApplicationId"),
    CONSTRAINT "Module_Fk1" FOREIGN KEY ("ApplicationId")
        REFERENCES public."Application" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Module"
    OWNER to postgres;
	

CREATE SEQUENCE public."ModuleSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 99999999999999999999
    CACHE 20;

ALTER SEQUENCE public."ModuleSeq"
    OWNER TO postgres;
	
	
	
Alter Table Public."Application" 
	Drop Constraint "Application_Chk1";