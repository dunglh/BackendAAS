ALTER TABLE public."Application" DISABLE TRIGGER ALL;
ALTER TABLE public."ApplicationRole" DISABLE TRIGGER ALL;
ALTER TABLE public."CredentialData" DISABLE TRIGGER ALL;
ALTER TABLE public."Module" DISABLE TRIGGER ALL;
ALTER TABLE public."ModuleRole" DISABLE TRIGGER ALL;
ALTER TABLE public."Role" DISABLE TRIGGER ALL;
ALTER TABLE public."User" DISABLE TRIGGER ALL;
ALTER TABLE public."UserRole" DISABLE TRIGGER ALL;



ALTER TABLE public."ApplicationRole" DROP CONSTRAINT "ApplicationRole_Fk1";
ALTER TABLE public."ApplicationRole" DROP CONSTRAINT "ApplicationRole_Fk2";
ALTER TABLE public."ModuleRole" DROP CONSTRAINT "ModuleRole_Fk1";
ALTER TABLE public."ModuleRole" DROP CONSTRAINT "ModuleRole_Fk2";
ALTER TABLE public."UserRole" DROP CONSTRAINT "UserRole_Fk1";
ALTER TABLE public."UserRole" DROP CONSTRAINT "UserRole_Fk2";
ALTER TABLE public."Module" DROP CONSTRAINT "Module_Fk1";