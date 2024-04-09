Feature: HiterNilve_Ser062

בדיקה האם קיימת היתכנות לקבלת היתר נלווה

1. בדיקה_האם_כבר_קיימת_בקשה_להיתר___בקשה_ישנה_לא_בטיפול
לוגיקה עסקית: אסורות שתי בקשות פעילות לאותו סוג היתר
ניתן לפתוח בקשה נוספת לכל סוג היתר חוץ מפרגוד, אם בקשה ישנה לא בטיפול
או יש היתר נלווה מסוג ההיתר שבקלט בסטטוס <> "הופק"  

2. בדיקה_האם_כבר_קיימת_בקשה_להיתר___בקשה_ישנה_בטיפול
לא ניתן לפתוח בקשה נוספת לכל סוג היתר, אם בקשה ישנה בטיפול

@Test
Scenario Outline: בדיקה_האם_כבר_קיימת_בקשה_להיתר___בקשה_ישנה_לא_בטיפול
	Given valid access token
	* default tik rishuy
	* run Ser028 create additional permit with parameters: <SugIter>, 0, 0.0, <NumOfIters>
	* update status of hiter bakasha to: <StatusHiterBakasha>
	* update tahanot of Hiter to status: <StatusHiterTahana>
	Then status of bakasha for HiterNilve in DB: <StatusHiterBakasha>, <NumOfHiterBakasha>
	Then status of tahanot for HiterNilve in DB: <StatusHiterTahana>, <NumOfHiterTahana>
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	Then Ser062 response should be: <ResponseResult>

Examples:
	| SugIter | StatusHiterBakasha | StatusHiterTahana | NumOfHiterBakasha | NumOfHiterTahana | NumOfIters | ResponseResult |
	| 1       | 3                  | 3                 | 1                 | 3                | 1          | true           |
	| 2       | 3                  | 3                 | 1                 | 3                | 1          | true           |
	| 3       | 3                  | 3                 | 1                 | 1                | 1          | true           |
	| 7       | 3                  | 3                 | 1                 | 1                | 1          | false          |
	| 8       | 3                  | 3                 | 1                 | 2                | 1          | true           |
	


@Test
Scenario Outline: בדיקה_האם_כבר_קיימת_בקשה_להיתר___בקשה_ישנה_בטיפול
	Given valid access token
	* default tik rishuy
	* run Ser028 create additional permit with parameters: <SugIter>, 0, 10.3, <NumOfIters>
	* update status of hiter bakasha to: <StatusHiterBakasha>
	Then status of bakasha for HiterNilve in DB: <StatusHiterBakasha>, <NumOfHiterBakasha>
	Then status of tahanot for HiterNilve in DB: 1, <NumOfHiterTahana>
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	Then Ser062 response should be: <ResponseResult>

Examples:
	| SugIter | StatusHiterBakasha | NumOfIters | NumOfHiterBakasha | NumOfHiterTahana | ResponseResult |
	| 1       | 4                  | 1          | 1                 | 3                | 'Request for additional permit exists, cannot open new reques'          |
	| 2       | 4                  | 1          | 1                 | 3                | 'Request for additional permit exists, cannot open new reques'           |
	| 3       | 4                  | 1          | 1                 | 1                | 'Request for additional permit exists, cannot open new reques'           |
	| 7       | 4                  | 1          | 1                 | 1                | 'Request for additional permit exists, cannot open new reques'           |
	| 8       | 4                  | 1          | 1                 | 2                | 'Request for additional permit exists, cannot open new reques'           |




@Test
Scenario Outline: קביעה_האם_בקשת_חידוש_ותאריך_תחילת_היתר_אפשרית
	Given valid access token
	* default tik rishuy
	* update objects creation date '-03-00-00T00:00', 'essek'
	* run Ser028 create additional permit with parameters: <SugIter>, 0, <requestArea>, 1
	* run Ser029 permit update with parameters: 10
	Then hiter nilve created in DB: 'Yes'
	Given update status Hiter to: 40
	Then Ser029 response description should be 'null'
	Given update objects creation date <TimeOffset>, 'hiter_nilve'
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then Ser062 response should be: <ResponseResult>
 


Examples:
	| TimeOffset        | SugIter | SibatBakasha | NumOfHiters | ResponseResult |
	| '-00-10-01T00:00' | 1       | 0            | 1           | false          |
	| '-00-10-01T00:00' | 2       | 0            | 1           | false          |
	| '-00-10-01T00:00' | 3       | 0            | 1           | false          |
	| '-00-10-01T00:00' | 4       | 0            | 1           | false          |
	| '-00-10-01T00:00' | 5       | 0            | 1           | false          |



# --בדיקת תלות ברישיון--
# --בדיקת תלות במהות ראשית--
# בודק בפלט שירות 066 אם יש רישיון בתוקף - אם כן ממשיך לבדיקה הבאה 
# בדיקת תלות במהות ראשית 

@Test
Scenario Outline: בדיקת_תלות_ברישיון
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 402200, 0, 10
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z", 8
	When update status of bakasha to: 3
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then additionalPermitPossibility: true

Examples:
	| SugIter |
	| 2       |

# --בדיקת תלות ברישיון--
# בודק בפלט שירות 066 אם יש בקשה לרישיון בסטטוס <> "סיום טיפול" - אם כן ממשיך לבדיקה הבאה

@Test
Scenario Outline: בדיקת_תלות_ברישיון_2
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 402200, 0, 10
	When update status of bakasha to: 4
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then additionalPermitPossibility: true

Examples:
	| SugIter |
	| 2       |

# --חוקים מיוחדים להיתר מרכול—
# בודק שטח העסק בפלט שירות אם השטח גדול מ<פרמטרים למערכת>.שטח מקסימום להיתר מרכול - סיבות לאי היתכנות להיתר נלווה "שטח מרכול גדול מידי

@Test
Scenario Outline: חוקים_מיוחדים_להיתר_מרכול
	Given valid access token
	Given default tik rishuy with parameters for mahut: 1, 2, 402200, 0, 501
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z", 8
	When update status of bakasha to: 3
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then additionalPermitPossibility: false - ["Supermarket area is too big"]

Examples:
	| SugIter |
	| 8       |

@Test
Scenario Outline: חוקים_מיוחדים_להיתר_מרכול_2
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 402200, 0, 500
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z", 8
	When update status of bakasha to: 3
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then additionalPermitPossibility: true

Examples:
	| SugIter |
	| 8       |


# --חוקים מיוחדים להיתר פרגוד—- 
# בודק האם יש לעסק היתר נלווה מסוג שולחנות, בסטטוס שונה מ"סורב", ותאריך סיום תוקף ההיתר אינו מוקדם מפרמטר פלט תאריך סיום עונת היתר 
# אם כן, קובע פרמטר פלט שטח מקסימלי = שטח שנקבע להיתר שולחנות וכסאות

@Test
Scenario Outline: חוקים_מיוחדים_להיתר_פרגוד
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 104200, 0, 13
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z", 8
	When update status of bakasha to: 3

	Given run Ser028 create additional permit with parameters: 2, 0, 9.0, 1
	* run Ser029 permit update with parameters: 40
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	#Then additionalPermitPossibility: true
	#Then "pergodPermitMaxArea": 9.00

Examples:
	| SugIter |
	| 3       |

# --חוקים מיוחדים להיתר פרגוד—- negative
# בודק האם יש לעסק היתר נלווה מסוג שולחנות, בסטטוס שונה מ"סורב", ותאריך סיום תוקף ההיתר אינו מוקדם מפרמטר פלט תאריך סיום עונת היתר 
# אם כן, קובע פרמטר פלט שטח מקסימלי = שטח שנקבע להיתר שולחנות וכסאות
@Test
Scenario Outline: חוקים_מיוחדים_להיתר_פרגוד_2
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 104200, 0, 13
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-01-13T10:00:00.100Z", 8
	When update status of bakasha to: 3
	Given run Ser028 create additional permit with parameters: 2, 0, 9.0, 1
	* run Ser029 permit update with parameters: 50
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	# Then additionalPermitPossibility: false
	# Then "This permit depends by another permit that dont exists in the business"

Examples:
	| SugIter |
	| 3       |

# --בדיקת תלות במהות ראשית--
# בודק האם קיימת בקשה להיתר נלווה מסוג שולחנות וכסאות, בסטטוס שונה מ"סורב", ותאריך סיום תוקף מבוקש אינו מוקדם מפרמטר פלט תאריך סיום עונת היתר
# אם כן, קובע פרמטר פלט שטח מקסימלי = שטח שנקבע להיתר שולחנות וכסאות

@Test
Scenario Outline: חוקים_מיוחדים_להיתר_פרגוד_3
	Given valid access token
	* default tik rishuy with parameters for mahut: 1, 2, 10, 0, 10
	When create draft license with parameters: 8, "2022-02-06T10:00:00.100Z", "2033-04-29T10:00:00.100Z", 8
	When update status of bakasha to: 3
	Given run Ser028 create additional permit with parameters: 2, 0, 9.0, 1
	* run Ser029 permit update with parameters: 40
	When run Ser066 get business data
	Given run Ser062 check additional permit possibility with parameters: <SugIter>
	# Then additionalPermitPossibility: false
	# Then "Business item does not match additional permit"

Examples:
	| SugIter |
	| 5       |



# אם סוג היתר נלווה בקלט == לילה
# בדיקה 1: העסק טעון רישוי + קבוצת רישוי לא כללית
# NULL קבוצת מהות כללית זה

@Test
Scenario Outline: GIS_לילה
	Given valid access token
	Given tik rishuy for GIS: 1, alef, <kvuzat_mahut>, <shat_sium_lefi_GIS>, <mediniut_layla>, <im_essek_taun_rishui>

	When run Ser066 get business data
	Given run GetGISLayer
	Given run Ser062 check additional permit possibility with parameters: 1

	#Then 1: "nightPermitStartHour": "00:00", "nightPermitEndHour": "02:00" - פלט 062
	#Then 2: "nightPermitStartHour": "21:00", "nightPermitEndHour": "05:00"
	#Then 3: "nightPermitStartHour": "21:00", "nightPermitEndHour": "05:00"
	#Then 4: "nightPermitStartHour": "00:00", "nightPermitEndHour": "01:00"
	#Then 5: "nightPermitStartHour": "00:00", "nightPermitEndHour": "23:00"
	#Then 6: "nightPermitStartHour": "00:00", "nightPermitEndHour": "03:00"
	#Then 7: "nightPermitStartHour": "00:00", "nightPermitEndHour": "05:00"
	#Then 7: "nightPermitStartHour": "00:00", "nightPermitEndHour": "05:00"

Examples:
	| im_essek_taun_rishui | kvuzat_mahut | shat_sium_lefi_GIS | mediniut_layla |
	| true                 | לא כללית     | true               | 2              |
	| true                 | כללית        | false              | 2              |
	| false                | כללית        | false              | 2              |

	| true                 | לא כללית     | true               | 1              |
	| true                 | לא כללית     | false              | 4              |
	| true                 | לא כללית     | false              | 5              |
	| true                 | לא כללית     | false              | 6              |


# אם סוג היתר נלווה בקלט == שבת יפה 
# בודק לפי הפלט של גיס האם כתובת העסק באזור יפו א' או יפו ב 

@Test
Scenario Outline: GIS_שבת
	Given valid access token
	Given tik rishuy for GIS: 7, <ezor_yafo>, לא כללית, true, 2, true
	When run Ser066 get business data
	Given run GetGISLayer
	Given run Ser062 check additional permit possibility with parameters: 7


Examples:
	| ezor_yafo |
	| alef      |
	| bet       |


	# --סוגי היתר נלווה -- [ris_tt_sug_heiter_nilve]
# Code  sug_cheadush  him_nidrash_tashlum_hagra  him_taloi_berishaion  teur
#	1		1			1							0					לילה
#	2		1			1							1					שולחנות		
#	3		2			1							1					פרגוד
#	4		1			0							0					שבת יפו
#	5		0			0							1					מרכול
#	6		0			0							NULL				דוכן

# sug_cheadush : 
# 0 – אין חידוש
# 1 – חידוש אוטומטי
# 2 – חידוש

# -- סטטוס היתר -- [ris_tt_status_heiter_zmani] -- StatusIter --
# Code	teur
# 10	ממתין לאישור אגף רישוי
# 20	ממתין לתשלום
# 30	ממתין להפקה
# 40	הופק
# 50	סורב
# 60	נדחה

# <StatusBakasha>: [ris_tt_status_bakasha]  
# 1 - נשלחה
# 2 - אושרה
# 3 - סיום טיפול
# 4 - בטיפול

# [ris_tt_status_tachana_measheret]
# 1	נשלח
# 2	טיפול
# 3	אישור
# 4	סירוב
# 5	תנאי מוקדם
# 8	לידיעה
# 11 היתר זמני
# 12 תזכורת
# 13 חידוש היתר
# 17 נדחה על ידי הפיקוח
# 18 אושר על ידי הפיקוח
# 19 בבדיקת גורם הפיקוח
# 20 אושרה בקשת מרכול לשבת
# 21 אושר היתר מזורז א
# 22 אושר היתר מזורז ב
# 23 אושר היתר מזורז א הארכה
# 24 אושר היתר מזורז ב הארכה
# 25 אושר אוטומטית
# 26 היתר זמני אוטומטית
# 27 אושר תצהיר
# 28 נדחה
# 98 בטיפול של בעל עסק
# 99 נדחה אוטומטית