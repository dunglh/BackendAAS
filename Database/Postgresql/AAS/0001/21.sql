ALTER TABLE public."Application"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."Application"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."Application"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."Application"
    ALTER COLUMN "IsActive" TYPE smallint ;
	
	
ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "IsActive" TYPE smallint ;

ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "ApplicationId" TYPE bigint ;

ALTER TABLE public."ApplicationRole"
    ALTER COLUMN "RoleId" TYPE bigint ;
	

ALTER TABLE public."CredentialData"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."CredentialData"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."CredentialData"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."CredentialData"
    ALTER COLUMN "IsActive" TYPE smallint ;
	
	
	
ALTER TABLE public."Module"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."Module"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."Module"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."Module"
    ALTER COLUMN "IsActive" TYPE smallint ;

ALTER TABLE public."Module"
    ALTER COLUMN "ApplicationId" TYPE bigint ;
	
	
ALTER TABLE public."ModuleRole"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "IsActive" TYPE smallint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "ModuleId" TYPE bigint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "RoleId" TYPE bigint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "IsAllowCreate" TYPE smallint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "IsAllowUpdate" TYPE smallint ;

ALTER TABLE public."ModuleRole"
    ALTER COLUMN "IsAllowDelete" TYPE smallint ;
	
	
ALTER TABLE public."Role"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."Role"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."Role"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."Role"
    ALTER COLUMN "IsActive" TYPE smallint ;
	
	
ALTER TABLE public."User"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."User"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."User"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."User"
    ALTER COLUMN "IsActive" TYPE smallint ;
	
	
	
ALTER TABLE public."UserRole"
    ALTER COLUMN "Id" TYPE bigint ;

ALTER TABLE public."UserRole"
    ALTER COLUMN "CreateTime" TYPE bigint ;

ALTER TABLE public."UserRole"
    ALTER COLUMN "ModifyTime" TYPE bigint ;

ALTER TABLE public."UserRole"
    ALTER COLUMN "IsActive" TYPE smallint ;

ALTER TABLE public."UserRole"
    ALTER COLUMN "UserId" TYPE bigint ;

ALTER TABLE public."UserRole"
    ALTER COLUMN "RoleId" TYPE bigint ;