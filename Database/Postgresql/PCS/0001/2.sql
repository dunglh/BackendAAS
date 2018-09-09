CREATE TABLE public."Project"
(
    "Id" bigint NOT NULL,
    "CreateTime" bigint,
    "ModifyTime" bigint,
    "Creator" character varying(50),
    "Modifier" character varying(50),
    "IsActive" smallint DEFAULT 1,
    "ProjectCode" character varying(6) NOT NULL,
    "ProjectName" character varying(500) NOT NULL,
    "ProjectSttId" bigint NOT NULL,
    "FinishTime" bigint,
    PRIMARY KEY ("Id"),
    CONSTRAINT "Project_Uk1" UNIQUE ("ProjectCode")
,
    CONSTRAINT "Project_Chk1" CHECK (LENGTH(To_Char("FinishTime",'9')) = 14) NOT VALID
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Project"
    OWNER to postgres;

COMMENT ON COLUMN public."Project"."ProjectSttId"
    IS 'Trang thai 1-chua xu ly; 2-dang xu ly; 3-hoan thanh';
	
	
Drop Constraint "Project_Chk1"



ALTER TABLE public."Project"
    ADD CONSTRAINT "Project_Chk1" CHECK (LENGTH("FinishTime" ::text)=14)
    NOT VALID;