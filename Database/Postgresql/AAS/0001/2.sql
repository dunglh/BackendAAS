CREATE TABLE public."Application"
(
    "Id" numeric(19) NOT NULL,
    "ApplicationCode" character varying(3) NOT NULL,
    "ApplicationName" character varying(500) NOT NULL,
    "CreateTime" numeric(14),
    "Creator" character varying(50),
    "ModifyTime" numeric(14),
    "Modifier" character varying(50),
    "IsActive" numeric(2),
    PRIMARY KEY ("Id"),
    CONSTRAINT "Application_Uk1" UNIQUE ("ApplicationCode"),
    CONSTRAINT "Application_Chk1" CHECK (("CreateTime" > 1000000000 and "CreateTime" < 99999999999999)) NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Application"
    OWNER to postgres;
	
	

CREATE SEQUENCE public."ApplicationSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 99999999999999999999
    CACHE 20;

ALTER SEQUENCE public."ApplicationSeq"
    OWNER TO postgres;
	

ALTER TABLE public."Application"
    ALTER COLUMN "IsActive" SET DEFAULT 1;