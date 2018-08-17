CREATE TABLE public."CredentialData"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" numeric(2) DEFAULT 1,
    "TokenCode" character varying(200) NOT NULL,
    "DataKey" character varying(100) NOT NULL,
    "Data" jsonb NOT NULL,
    PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."CredentialData"
    OWNER to postgres;
	
	
	
CREATE SEQUENCE public."CredentialDataSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 99999999999999999999
    CACHE 20;

ALTER SEQUENCE public."CredentialDataSeq"
    OWNER TO postgres;