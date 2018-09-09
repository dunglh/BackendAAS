CREATE TABLE public."Address"
(
    "Id" bigint NOT NULL,
    "CreateTime" bigint,
    "ModifyTime" bigint,
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" smallint DEFAULT 1,
    "BaseUrl" character varying(250) NOT NULL,
    "Loginname" character varying(50) NOT NULL,
    "Password" character varying(50) NOT NULL,
    "BlogId" integer,
    "ProjectId" bigint NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Address_Fk1" FOREIGN KEY ("ProjectId")
        REFERENCES public."Project" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Address"
    OWNER to postgres;
	
	
	
CREATE TABLE public."Post"
(
    "Id" bigint NOT NULL,
    "CreateTime" bigint,
    "ModifyTime" bigint,
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" smallint DEFAULT 1,
    "ProjectId" bigint NOT NULL,
    "Title" character varying(500) NOT NULL,
    "PostTime" bigint,
    "Status" character varying(50),
    "PostType" character varying(50),
    "Content" text NOT NULL,
    "Author" character varying(100),
    "Tags" character varying(1000),
    "AddressId" bigint NOT NULL,
    "PostSttId" integer NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Post_Fk1" FOREIGN KEY ("ProjectId")
        REFERENCES public."Project" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Post_Fk2" FOREIGN KEY ("AddressId")
        REFERENCES public."Address" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Post_Chk1" CHECK (LENGTH("PostTime"::text) = 14) NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Post"
    OWNER to postgres;