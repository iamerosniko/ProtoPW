USE [dbbtVulTstp1]
GO
/****** Object:  StoredProcedure [dbo].[PW_GetVideo]    Script Date: 7/25/2017 1:48:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[PW_GetVideo]
@username varchar(15),
@isLeader bit
as begin
	if(@isLeader = cast(1 as bit))
		select 
			r.ResourcePath as [ResourcePath],
			r.ResourceCategory
		from 
			PW_TemporaryUsers p
		left join PW_Leaders l
			on p.LeaderID=l.LeaderID
		left join 
			PW_Resources r
			on r.ResourceID=l.LeaderResourceID
		where p.ID=@username
		and p.IsActive=cast(1 as bit)
		order by p.id desc
	else
		select 
			r.ResourcePath as [ResourcePath],
			r.ResourceCategory
		from 
			PW_TemporaryUsers p
		left join PW_Leaders l
			on p.LeaderID=l.LeaderID
		left join 
			PW_Resources r
			on r.ResourceID=l.ManagerResourceID
		where p.id=@username
		and p.IsActive=cast(1 as bit)
		order by p.id desc
end




