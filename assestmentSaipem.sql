use AssesmentSaipem;

CREATE TABLE company_1(
	company_code_1 char(2) NOT NULL PRIMARY KEY,
	company_name varchar(6) 
);

CREATE TABLE company_2(
	company_code_2 char(4) NOT NULL PRIMARY KEY,
	company_code_1 char(2) FOREIGN KEY REFERENCES company_1(company_code_1),
	company_name varchar(16)
);

INSERT INTO company_1
VALUES 
	('SP', 'SAIPEM'),
	('JV', 'CCS JV');

INSERT INTO company_2
VALUES
	('SPA', 'SP', 'SAIPEM MILAN'),
	('PTSI', 'SP', 'SAIPEM INDONESIA'),
	('JVA','JV','CCS JV ASIA'),
	('JVM', 'JV', 'CCS JV MILAN');

GO
CREATE VIEW [DataCompany]
AS 
	SELECT 
		c1.company_code_1 as [c1Code1],
		c1.company_name as [c1Name],
		c2.company_code_2 as [c2Code2],
		c2.company_code_1 as [c2Code1],
		c2.company_name as [c2Name]
	FROM company_1 AS c1 
	LEFT JOIN company_2 AS c2 
		ON c1.company_code_1 = c2.company_code_1;

GO 
SELECT 
	[c1Code1] [ ],
	[c1Name] [ ],
	[c2Code2] [ ],
	[c2Name] [ ]
FROM [DataCompany]
WHERE [c1Name] = 'SAIPEM'
ORDER BY [c2Code2] DESC;