﻿SELECT
	mpm.id,
	mpm.fromNodeId as id,
	mpm.toNodeId as id,
	mpm.medicalAppointmentId as id
FROM
	MedicalAppointmentMovement mpm
WHERE 
	mpm.fromNodeId = @fromNodeId AND
	mpm.medicalAppointmentId = @medicalAppointmentId