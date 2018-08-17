ALTER TABLE public."ApplicationRole"
    ADD CONSTRAINT "ApplicationRole_Fk1" FOREIGN KEY ("ApplicationId")
    REFERENCES public."Application" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE public."ApplicationRole"
    ADD CONSTRAINT "ApplicationRole_Fk2" FOREIGN KEY ("RoleId")
    REFERENCES public."Role" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
	
	
ALTER TABLE public."Module"
    ADD CONSTRAINT "Module_Fk1" FOREIGN KEY ("ApplicationId")
    REFERENCES public."Application" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
	
	
ALTER TABLE public."ModuleRole"
    ADD CONSTRAINT "ModuleRole_Fk1" FOREIGN KEY ("ModuleId")
    REFERENCES public."Module" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE public."ModuleRole"
    ADD CONSTRAINT "ModuleRole_Fk2" FOREIGN KEY ("RoleId")
    REFERENCES public."Role" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
	
	
ALTER TABLE public."UserRole"
    ADD CONSTRAINT "UserRole_Fk1" FOREIGN KEY ("UserId")
    REFERENCES public."User" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;

ALTER TABLE public."UserRole"
    ADD CONSTRAINT "UserRole_Fk2" FOREIGN KEY ("RoleId")
    REFERENCES public."Role" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
	
	
ALTER TABLE public."CredentialData"
    ALTER COLUMN "Data" TYPE json ;
	
	
ALTER TABLE public."CredentialData" DROP COLUMN "Data";

ALTER TABLE public."CredentialData"
    ADD COLUMN "Data" text;