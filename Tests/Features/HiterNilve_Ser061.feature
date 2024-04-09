Feature: HiterNilve_Ser061

חישוב תעריף האגרה שנדרש לשלם עבור קבלת היתר נלווה
SWAGGER: LISENCE /api​/AdditionalPermit​/FeeCalculation

@Test
Scenario: [scenario name]
	Given valid access token
	* default tik rishuy with parameters for mahut: <NumOfMahuyot>, <Maslul>, <MahutRashit>
	* run Ser028 create additional permit with parameters: <SugIter>, <SibatBakasha>, <NumOfAdditionalIters>
	* run Ser029 permit update with parameters: <StatusIter>
	When run Ser061 FeeCalculation with parameters: <hiterStartDate>, <hiterEndDate>, <hiterEndHour>, <hiterStartHour>, <area>


Examples: 
	| NumOfMahuyot | Maslul | MahutRashit | SugIter | SibatBakasha | NumOfAdditionalIters | StatusIter | hiterStartDate             | hiterEndDate               | hiterEndHour | hiterStartHour | area |
	| 1            | 1      | 9           | 1       | 0            | 1                    | 10         | "2024-01-02T21:32:49.087Z" | "2024-01-02T21:32:49.087Z" | "string"     | "string"       | 0    |
