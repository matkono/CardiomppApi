﻿SELECT 
	a.Id as actionId,
	a.code,
	a.title,
	n.id,
	n.isInitial,
	n.nodeTypeId as id,
	n.decisionTreeId as id
FROM 
	Action a
INNER JOIN Node n ON
	n.id = a.nodeId
WHERE
	a.nodeId = @NodeId