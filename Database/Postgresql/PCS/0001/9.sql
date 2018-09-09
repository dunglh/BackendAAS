ALTER TABLE public."Post"
    ADD COLUMN "ApprovalLoginname" character varying(50);

ALTER TABLE public."Post"
    ADD COLUMN "ApprovalUsername" character varying(100);

ALTER TABLE public."Post"
    ADD COLUMN "ApprovalTime" bigint;
ALTER TABLE public."Post"
    ADD CONSTRAINT "Post_Chk2" CHECK (LENGTH("ApprovalTime"::text) = 14)
    NOT VALID;