USE [dbbtVulTstp1]
GO
/****** Object:  StoredProcedure [dbo].[PW_GetResourcePath2]    Script Date: 7/25/2017 1:47:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[PW_GetResourcePath2]
@username varchar(15),
@resourceCategory varchar(50)
as begin
	select 
		r.ResourcePath as [ResourcePath],
		r.ResourceCategory,
		p.*
	from 
		PW_TemporaryUsers p
	left join 
		PW_TeamResources tr
		on p.TeamID=tr.TeamID
	left join 
		PW_Resources r
		on r.ResourceID=tr.ResourceID
	where p.ID=@username
	and p.IsActive=cast(1 as bit)
	and r.ResourceCategory=@resourceCategory
	order by p.id desc
end



