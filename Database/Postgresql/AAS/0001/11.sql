Create Or Replace Function User_1() Returns Trigger As $$
	Declare
		v_newVal numeric(19) := 0;
		v_time numeric(14) := 0;
	Begin
		
		Select Cast(To_Char(Current_Timestamp,'YYYYMMDDHH24MISS') As numeric) Into v_time;
		New."CreateTime" := v_time;
		New."ModifyTime" := v_time;
		New."Modifier" := New."Creator";
		If New."Id" is null or New."Id" = 0 Then
			Select NextVal('"public"."UserSeq"') Into v_newVal;
			New."Id" := v_newVal;
		End If;
		If New."IsActive" Is Null Then
			New."IsActive" := 1;
		End If;
		Return New;
	End;
$$ LANGUAGE plpgsql;


Create Or Replace Function User_2() Returns Trigger As $$
	Declare
		v_time numeric(14) := 0;
	Begin		
		Select Cast(To_Char(Current_Timestamp,'YYYYMMDDHH24MISS') As numeric) Into v_time;
		New."ModifyTime" := v_time;
		Return New;
	End;
$$ LANGUAGE plpgsql;


CREATE TRIGGER "User_1"
    BEFORE INSERT
    ON public."User"
    FOR EACH ROW
    EXECUTE PROCEDURE public.user_1();
	
	
CREATE TRIGGER "User_2"
    BEFORE UPDATE
    ON public."User"
    FOR EACH ROW
    EXECUTE PROCEDURE public.user_2();