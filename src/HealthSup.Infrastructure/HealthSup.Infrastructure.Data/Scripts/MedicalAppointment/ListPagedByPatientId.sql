﻿SELECT
	ma.id,
	ma.isDiagnostic,
	p.id,
	dt.id,
	ma.currentNodeId as id,
	ma.medicalAppointmentStatusId as id
FROM
	MedicalAppointment ma
INNER JOIN Patient p ON
	p.id = ma.patientId
INNER JOIN DecisionTree dt ON
	dt.id = ma.decisionTreeId
WHERE
	ma.id = @PatientId
ORDER BY ma.id
OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;