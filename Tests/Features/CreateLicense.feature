Feature: CreateDraftLicense
טסטים לתהליך יצירת טיוטה (באג, צריך להריץ אפי פעמיים),
יצירת סירוב > בעל עסק מוותר על שימוע (אפי) > סיום תהליך סירוב > רישיון מגיעה 
bug - 18011
@Test
Scenario Outline: create draft license
	Given valid access token
	* default tik rishuy
	When update status of tahanot meashrot to 3
	When create draft license with parameters: <fileType>, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	#When create draft license with parameters: 8, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	#Then [קיבלנו טיוטה במסך אישור רשיונות]

Examples:
	| fileType | startLicenseDate           | endLicenseDate             | licenseItemType |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 1               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 2               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 3               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 4               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 5               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 6               |
	| 7        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 8               |



@Test
Scenario Outline: create seruv
	Given valid access token
	* default tik rishuy
	When create draft license with parameters: 7, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	#When create draft license with parameters: 8, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	When update status of tahanot meashrot to 4
	* create seruv in DB with parameters: <sugSeruv>
	#Then [קיבלנו רשומת סירוב במסך סירוב לרישיון]

Examples:
	| sugSeruv | startLicenseDate           | endLicenseDate             | licenseItemType |
	| 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 1               |
	| 2        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 2               |
	| 1        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 3               |
	| 2        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 4               |
	| 1        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 5               |
	| 2        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 6               |
	| 1        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 7               |
	| 1        | "2023-12-29T10:00:00.100Z" | "2033-12-29T10:00:00.100Z" | 8               |



@Test
Scenario Outline: business owner waived the right to a hearing
	Given valid access token
	* default tik rishuy
	When create draft license with parameters: 7, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	#* create draft license with parameters: 8, <startLicenseDate>, <endLicenseDate>, <licenseItemType>
	* update status of tahanot meashrot to 4
	* create seruv in DB with parameters: <sugSeruv>
	* update Refuse Scheduled Hearing with parameters: <contactDateTime>, <tiumShimua>
	* cancel refuse license
	#Then [קיבלנו רשומת ביטול במסך ביטולים]


Examples:
	| contactDateTime            | tiumShimua | sugSeruv | startLicenseDate           | endLicenseDate             | licenseItemType |
	| "2024-01-15T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 1               |
	| "2024-02-25T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 2               |
	| "2024-02-28T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 3               |
	| "2024-01-12T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 4               |
	| "2024-01-20T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 5               |
	| "2024-01-19T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 6               |
	| "2024-02-01T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 7               |
	| "2024-01-09T10:00:00.100Z" | false      | 1        | "2023-12-31T10:00:00.100Z" | "2033-12-31T10:00:00.100Z" | 8               |


@Test
Scenario Outline: create license and seruv in DB
	Given valid access token
	* default tik rishuy
	When create draft license with parameters: 8, <startLicenseDate>, <endLicenseDate>, 8
	When create seruv in DB with parameters: <sugSeruv>

Examples:
	| SugTofes | SugRishayon | startLicenseDate           | endLicenseDate             | sugSeruv |
	| 8        | 3           | "2024-02-06T10:00:00.100Z" | "2033-01-13T10:00:00.100Z" | 2        |



@Test
Scenario: create license waiting for approval in DB
	Given valid access token
	* default tik rishuy
	When create license in DB: 2, <SugTofes>, <SugRishayon>,  <startLicenseDate>, <endLicenseDate>

Examples:
	| SugTofes | SugRishayon | startLicenseDate           | endLicenseDate             |
	| 8        | 3           | "2024-02-06T10:00:00.100Z" | "2033-01-13T10:00:00.100Z" |

# <contactDateTime> = תאריך שימוע

# -- רישיון --[ris_tt_sug_rishayon]
# Code	teur
# 1	חידוש
# 2	היתר זמני
# 3	תקופתי
# 4	מבוטל
# 5	צמיתות
# 6	כפל
# 7	היתר מזורז א
# 8	היתר מזורז ב

# -- סוג תופס -- [ris_tt_sug_tofes]
# Code	teur
# 7     היתר זמני/מזורז 
# 8 	רישיון קבוע

# -- סטטוס רישיון -- [ris_tt_status_rishayun]
# Code	teur
# 1 	ממתין לתשלום
# 2 	ממתין לאישור אגף רשוי
# 3 	הופק
# 4 	הופק

# -- סוג סירוב --
# Code	teur
# 1 	סירוב בעקבות אי תשלום
# 2 	סירוב שהבשיל לביטול

# 1 – סירובים פעילים לרישיון
# 2 – סירובים לרישיון שהבשילו לביטול
# 3 – סירובים פעילים להיתר נלווה
# 4 – היסטוריית סירובים
# 5 – כל הסירובים לתיק עסק
# 6 – סירובים להיתר נלווה שהבשילו לביטול 