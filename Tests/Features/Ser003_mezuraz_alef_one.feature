Feature: Ser003_mezuraz_alef_one

Testing service 003

Background: 

    Given tik essek identification
		  | CodeEssek | BakashaId |
		  | 17        | 110       |

	Given tik essek data
	      | NumOfMahuyotInEssek | NumOfMahuyotInBakasha |
	      | 1                   | 1                     |
    Given tahanot in bakasha
	      | NumOfInnerTahanot | NumOfOuterTahanot |
		  | 1                 | 1                 |

	Given tahanot names in bakasha
	      | InnerTahanaName | OuterTahanaName    |
	      | משרד העבודה והרווחה |   נגישות ביקורת |

	Given tahanot emails
	      | EmailInnerTahana           | EmailOuterTahana      |
		  | nagishut_bikoret@gmail.com | misrad_avoda@gmail.com |

    Given baaley inyan in tik essek
	      | BaalInyanEmail                 |
	      | test_be_mezuraz_alef@gmail.com |
#
#    And ManagerStationsWorkingProcess executed
	And Calculate Works Days for day "0"
	And bakashot reset from [ris_t_bakasha]
#	And tahanot reset from [ris_t_tachana_measheret]
#	And tahanot deleted from [ris_t_haarachat_moed_lemahut]
#	And atraa deleted from [ris_t_atraa_letachana_measheret]
#	And tahanot email deleted from [ris_t_channel_messages_audit]
#	And baaley inyan email deleted from [ris_t_channel_messages_audit]
#	And outer tahana updated to "לידיעה", inner tahana updated to "נשלח"



@Test
@ser003
Scenario Outline: system_behavior
	Given tik essek in TlvClientsApps
	When update creation day of bakasha to <days_back>
	And update creation day of tahanot to <days_back>
	And execute "ManagerStationsWorkingProcess"
	Then tik essek in TlvClientsApps matches input data
	Then inner tahana status should be <inner_tahana_status>
	Then outer tahana status should be <outer_tahana_status>
	Then "messages audit" should be <messages_audit>
	Then "atraa letachana measheret" should be <atraa_letachana_measheret>
	Then "haarachat moed lemahut" should be <haarachat_moed_lemahut>

Examples: 
| days_back | inner_tahana_status | outer_tahana_status | atraa_letachana_measheret | messages_audit | haarachat_moed_lemahut |
| 1         | לידיעה |                נשלח              | no_records                | no_records     | no_records             |
| 2         | לידיעה |                נשלח              | no_records                | no_records     | no_records             |
| 3         | לידיעה |                נשלח              | no_records                | no_records     | no_records             |

