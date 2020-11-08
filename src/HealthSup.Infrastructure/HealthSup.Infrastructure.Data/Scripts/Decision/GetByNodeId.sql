﻿SELECT 
	d.Id as decisionId,
	d.code,
	d.title,
	d.isDiagnostic,
	n.id,
	n.isInitial,
	n.nodeTypeId as id,
	n.decisionTreeId as id
FROM 
	Decision d
INNER JOIN Node n ON
	n.id = d.nodeId
WHERE
	d.nodeId = @nodeId