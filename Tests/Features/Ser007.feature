Feature: Ser007

השירות מכין רשומת הודעה לשליחה במייל/מסרון בכל עת שמתעורר במערכת צורך לשלוח הודעה.

# Ser008 יצירת תחנה מאשרת
# ---שליחת הודעה לתחנה חיצונית על פתיחת התחנה---

#@repeat
@Test
Scenario: הכנת_הודעה_באירוע_הפצה_01
	Given valid access token
	* default tik rishuy with parameters for api mahut: 2, 3, 402100
#		Given update objects creation date '-01-02-00T00:00', 'essek'
#	When create license in DB: 4, 2, 3,  "2023-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z"
#	When create draft license with parameters: 7, "2023-08-01T10:00:00.100Z", "2033-12-29T10:00:00.100Z", 2

#	Given update objects creation date '-02-00-00T00:00', 'essek'
#	Given run Ser028 create additional permit with parameters: 1, 0, 100, 1
#
#	Given update objects creation date '-00-00-10T00:00', 'hiter_nilve'
#	Given run Ser029 permit update with parameters: 4
#
#
#	Given run Ser062 check additional permit possibility with parameters: 3

	  #Examples:
   # | repeat |
   # | 1      |
   # | 2      |
   # | 3      |
    #| 4      |
    #| 5      |
 #   | 6      |
 #   | 7      |
 #   | 8      |
 #   | 9      |
	#| 10     |



# Ser029 עדכון היתר נלווה   
# אם סטטוס ההיתר "הופק" מפעיל שירות 007 הכנת הודעה להפצה 

@Test
Scenario: הכנת_הודעה_באירוע_הפצה_02
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 407200, 0, 122
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