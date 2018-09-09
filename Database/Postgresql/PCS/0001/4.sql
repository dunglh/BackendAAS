CREATE TABLE public."Employee"
(
    "Id" bigint NOT NULL,
    "CreateTime" bigint,
    "ModifyTime" bigint,
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" smallint DEFAULT 1,
    "Loginname" character varying(50) NOT NULL,
    "RoleId" integer NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Employee_Uk1" UNIQUE ("Loginname")

)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Employee"
    OWNER to postgres;