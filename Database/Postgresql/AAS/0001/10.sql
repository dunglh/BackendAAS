CREATE TABLE public."User"
(
    "Id" numeric(19) NOT NULL,
    "CreateTime" numeric(14),
    "ModifyTime" numeric(14),
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" numeric(2) DEFAULT 1,
    "Loginname" character varying(50) NOT NULL,
    "Username" character varying(150) NOT NULL,
    "Password" character varying(200) NOT NULL,
    "Mobile" character varying(11),
    "Email" character varying(150),
    PRIMARY KEY ("Id"),
    CONSTRAINT "User_Uk1" UNIQUE ("Loginname")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."User"
    OWNER to postgres;
	
	
CREATE SEQUENCE public."UserSeq"
    INCREMENT 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 20;

ALTER SEQUENCE public."UserSeq"
    OWNER TO postgres;