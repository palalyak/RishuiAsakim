Feature: Ser007

השירות מכין רשומת הודעה לשליחה במייל/מסרון בכל עת שמתעורר במערכת צורך לשלוח הודעה.

# Ser008 יצירת תחנה מאשרת
# ---שליחת הודעה לתחנה חיצונית על פתיחת התחנה---

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_01
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 3, 7, 0, 10
	When create draft license with parameters: 8, "2023-12-29T10:00:00.100Z", "2033-12-29T10:00:00.100Z", 7
	Given run Ser028 create additional permit with parameters: 1, 0, 25, 1
	Given run Ser029 permit update with parameters: 1


# Ser029 עדכון היתר נלווה   
# אם סטטוס ההיתר "הופק" מפעיל שירות 007 הכנת הודעה להפצה 

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_02
	Given valid access token
	* default tik rishuy
	* run Ser028 create additional permit with parameters: 1, 0, 0.0, 1
	* run Ser029 permit update with parameters: 10
	Then Ser029 response description should be 'null'
	Then status of HiterNilve in DB: 10
	#Then validate hiter nilve: 0

	When run ischur hiter nilve 4 times


# S012 אישור רישיון  
# ליצור רישיון ממתין לאישור
# מפעיל שירות 007 הכנת הודעה להפצה לאחר אישור רישיון שממתין לאישור 

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_03
	Given valid access token
	* default tik rishuy
	When create license in DB: 2, 8, 3,  "2024-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z"