ˆ
TC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Validators\SpeakerValidator.cs
	namespace 	

ConsoleApp
 
. 

Validators 
{ 
public 

class 
SpeakerValidator !
:" #

IValidator$ .
{ 
public 
bool 
IsValid 
( 
Speaker #
speaker$ +
)+ ,
{ 	!
CheckNullOrWhitespace		 !
(		! "
speaker		" )
.		) *
	FirstName		* 3
,		3 4
$str		5 A
)		A B
;		B C!
CheckNullOrWhitespace

 !
(

! "
speaker

" )
.

) *
LastName

* 2
,

2 3
$str

4 ?
)

? @
;

@ A!
CheckNullOrWhitespace !
(! "
speaker" )
.) *
Email* /
,/ 0
$str1 8
)8 9
;9 :
return 
true 
; 
} 	
private 
void !
CheckNullOrWhitespace *
(* +
string+ 1
value2 7
,7 8
string9 ?
	paramName@ I
)I J
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
value* /
)/ 0
)0 1
{ 
throw 
new !
ArgumentNullException /
(/ 0
	paramName0 9
+: ;
$str< K
)K L
;L M
} 
} 	
} 
} Í
TC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Validators\SessionValidator.cs
	namespace 	

ConsoleApp
 
. 

Validators 
{ 
public 

class 
SessionValidator !
:" #

IValidator$ .
{ 
private 
readonly 
List 
< 
string $
>$ %!
_outdatedTechnologies& ;
=< =
new> A
ListB F
<F G
stringG M
>M N
{O P
$strQ X
,X Y
$strZ g
,g h
$stri t
,t u
$str	v Ä
}
Å Ç
;
Ç É
public

 
bool

 
IsValid

 
(

 
Speaker

 #
speaker

$ +
)

+ ,
{ 	
List 
< 
Session 
> 
sessions "
=# $
speaker% ,
., -
Sessions- 5
;5 6
if 
( 
sessions 
. 
Count 
== !
$num" #
)# $
{ 
throw 
new 
ArgumentException +
(+ ,
$str, a
)a b
;b c
} 
bool 
anyApproved 
= 
false $
;$ %
foreach 
( 
var 
session  
in! #
sessions$ ,
), -
{ 
if 
( !
_outdatedTechnologies )
.) *
Exists* 0
(0 1
tech1 5
=>6 8
session9 @
.@ A
TitleA F
.F G
ContainsG O
(O P
techP T
)T U
||V X
sessionY `
.` a
Descriptiona l
.l m
Containsm u
(u v
techv z
)z {
){ |
)| }
{ 
session 
. 
Approved $
=% &
false' ,
;, -
} 
else 
{ 
session 
. 
Approved $
=% &
true' +
;+ ,
anyApproved 
=  !
true" &
;& '
} 
} 
return 
anyApproved 
; 
}   	
}!! 
}"" Æ#
ZC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Validators\QualificationValidator.cs
	namespace 	

ConsoleApp
 
. 

Validators 
{ 
public 

class "
QualificationValidator '
:( )

IValidator* 4
{ 
private 
const 
int #
RequiredExperienceYears 1
=2 3
$num4 6
;6 7
private		 
const		 
int		 "
RequiredCertifications		 0
=		1 2
$num		3 4
;		4 5
private

 
const

 
int

 "
RequiredBrowserVersion

 0
=

1 2
$num

3 4
;

4 5
private 
readonly 
List 
< 
string $
>$ %
_domains& .
=/ 0
new1 4
List5 9
<9 :
string: @
>@ A
{B C
$strD M
,M N
$strO \
,\ ]
$str^ k
,k l
$strm }
}~ 
;	 Ä
private 
readonly 
List 
< 
string $
>$ %
_preferredEmployers& 9
=: ;
new< ?
List@ D
<D E
stringE K
>K L
{M N
$strO Z
,Z [
$str\ d
,d e
$strf z
,z {
$str	| á
}
à â
;
â ä
public 
bool 
IsValid 
( 
Speaker #
speaker$ +
)+ ,
{ 	
return 3
'HasSufficientExperienceOrCertifications :
(: ;
speaker; B
)B C
||D F
IsPreferredEmployer &
(& '
speaker' .
). /
||0 2
(  
IsUsingModernBrowser (
(( )
speaker) 0
)0 1
&&2 4
!5 6(
IsUsingRestrictedEmailDomain6 R
(R S
speakerS Z
)Z [
)[ \
;\ ]
} 	
private 
bool 3
'HasSufficientExperienceOrCertifications <
(< =
Speaker= D
speakerE L
)L M
{ 	
return 
speaker 
. 
ExperienceYears *
>+ ,#
RequiredExperienceYears- D
||E G
speaker 
. 
HasBlog "
||# %
speaker 
. 
Certifications )
.) *
Count* /
>0 1"
RequiredCertifications2 H
;H I
} 	
private 
bool 
IsPreferredEmployer (
(( )
Speaker) 0
speaker1 8
)8 9
{ 	
return 
_preferredEmployers &
.& '
Contains' /
(/ 0
speaker0 7
.7 8
Employer8 @
)@ A
;A B
} 	
private!! 
bool!!  
IsUsingModernBrowser!! )
(!!) *
Speaker!!* 1
speaker!!2 9
)!!9 :
{"" 	
return## 
speaker## 
.## 
Browser## "
.##" #
Name### '
!=##( *

WebBrowser##+ 5
.##5 6
BrowserName##6 A
.##A B
InternetExplorer##B R
||##S U
speaker$$ 
.$$ 
Browser$$ "
.$$" #
MajorVersion$$# /
>=$$0 2"
RequiredBrowserVersion$$3 I
;$$I J
}%% 	
private'' 
bool'' (
IsUsingRestrictedEmailDomain'' 1
(''1 2
Speaker''2 9
speaker'': A
)''A B
{(( 	
var)) 
emailDomain)) 
=)) 
speaker)) %
.))% &
Email))& +
.))+ ,
Split)), 1
())1 2
$char))2 5
)))5 6
;))6 7
var** 
domain** 
=** 
emailDomain** $
[**$ %
emailDomain**% 0
.**0 1
Length**1 7
-**8 9
$num**: ;
]**; <
;**< =
return++ 
_domains++ 
.++ 
Contains++ $
(++$ %
domain++% +
)+++ ,
;++, -
},, 	
}-- 
}.. ù
NC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Validators\IValidator.cs
	namespace 	

ConsoleApp
 
. 

Validators 
{ 
public 

	interface 

IValidator 
{ 
bool 
IsValid 
( 
Speaker 
speaker $
)$ %
;% &
} 
}		 £
LC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\WebBrowser.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 
class 

WebBrowser 
{ 
public 
BrowserName	 
Name 
{ 
get 
;  
set! $
;$ %
}& '
public 
int	 
MajorVersion 
{ 
get 
;  
set! $
;$ %
}& '
public 

WebBrowser	 
( 
string 
name 
,  
int! $
majorVersion% 1
)1 2
{		 
Name

 
=

 	(
TranslateStringToBrowserName


 &
(

& '
name

' +
)

+ ,
;

, -
MajorVersion 
= 
majorVersion 
; 
} 
private 	
BrowserName
 (
TranslateStringToBrowserName 2
(2 3
string3 9
name: >
)> ?
{ 
if 
( 
name 
. 
Contains 
( 
$str 
) 
) 
return "
BrowserName# .
.. /
InternetExplorer/ ?
;? @
return 	
BrowserName
 
. 
Unknown 
; 
} 
public 
enum	 
BrowserName 
{ 
Unknown 

,
 
InternetExplorer 
, 
Firefox 

,
 
Chrome 	
,	 

Opera 
, 	
Safari 	
,	 

Dolphin 

,
 
	Konqueror 
, 
Linx 
} 
}   
}!! «
ZC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\SpeakerValidationService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

class $
SpeakerValidationService )
:* +%
ISpeakerValidationService, E
{ 
private		 
readonly		 

IValidator		 #
_speakerValidator		$ 5
,		5 6
_sessionValidator		7 H
,		H I#
_qualificationValidator		J a
;		a b
public $
SpeakerValidationService '
(' (

IValidator( 2
speakerValidator3 C
,C D

IValidatorE O
sessionValidatorP `
,` a

IValidatorb l#
qualificationValidator	m É
)
É Ñ
{ 	
_speakerValidator 
= 
speakerValidator  0
;0 1
_sessionValidator 
= 
sessionValidator  0
;0 1#
_qualificationValidator #
=$ %"
qualificationValidator& <
;< =
} 	
public 
bool 
ValidateSpeaker #
(# $
Speaker$ +
speaker, 3
)3 4
{ 	
return 
_speakerValidator $
.$ %
IsValid% ,
(, -
speaker- 4
)4 5
;5 6
} 	
public 
bool 
ValidateSessions $
($ %
Speaker% ,
speaker- 4
)4 5
{ 	
bool 
sessionsApproved !
=" #
_sessionValidator$ 5
.5 6
IsValid6 =
(= >
speaker> E
)E F
;F G
if 
( 
! 
sessionsApproved !
)! "
{ 
throw 
new (
SessionsNotApprovedException 6
(6 7
$str7 N
)N O
;O P
} 
return 
sessionsApproved #
;# $
} 	
public!! 
bool!! "
ValidateQualifications!! *
(!!* +
Speaker!!+ 2
speaker!!3 :
)!!: ;
{"" 	
bool## 
isQualified## 
=## #
_qualificationValidator## 6
.##6 7
IsValid##7 >
(##> ?
speaker##? F
)##F G
;##G H
if$$ 
($$ 
!$$ 
isQualified$$ 
)$$ 
{%% 
throw&& 
new&& .
"SpeakerRequirementsNotMetException&& <
(&&< =
$str&&= z
)&&z {
;&&{ |
}'' 
return(( 
isQualified(( 
;(( 
})) 	
}** 
}++ °
PC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\SpeakerService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

class 
SpeakerService 
:  !
ISpeakerService" 1
{		 
private

 
readonly

 
IRepository

 $
_repository

% 0
;

0 1
private 
readonly %
ISpeakerValidationService 2%
_speakerValidationService3 L
;L M
private 
readonly 
IFeeService $
_feeService% 0
;0 1
public 
SpeakerService 
( 
IRepository )

repository* 4
,4 5%
ISpeakerValidationService6 O$
speakerValidationServiceP h
,h i
IFeeServicej u

feeService	v Ä
)
Ä Å
{ 	
_repository 
= 

repository $
;$ %%
_speakerValidationService %
=& '$
speakerValidationService( @
;@ A
_feeService 
= 

feeService $
;$ %
} 	
public 
int 
? 
Register 
( 
Speaker $
speaker% ,
), -
{ 	%
_speakerValidationService %
.% &
ValidateSpeaker& 5
(5 6
speaker6 =
)= >
;> ?%
_speakerValidationService %
.% &"
ValidateQualifications& <
(< =
speaker= D
)D E
;E F%
_speakerValidationService %
.% &
ValidateSessions& 6
(6 7
speaker7 >
)> ?
;? @
speaker 
. 
RegistrationFee #
=$ %
_feeService& 1
.1 2
CalculateFee2 >
(> ?
speaker? F
.F G
ExperienceYearsG V
)V W
;W X
return 
SaveSpeaker 
( 
speaker &
)& '
;' (
}   	
private"" 
int"" 
?"" 
SaveSpeaker""  
(""  !
Speaker""! (
speaker"") 0
)""0 1
{## 	
return$$ 
_repository$$ 
.$$ 
SaveSpeaker$$ *
($$* +
speaker$$+ 2
)$$2 3
;$$3 4
}%% 	
}&& 
}'' ø
IC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\Session.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 
class 
Session 
{ 
public 
string	 
Title 
{ 
get 
; 
set  
;  !
}" #
public		 
string			 
Description		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
bool

	 
Approved

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
Session	 
( 
string 
title 
, 
string %
description& 1
)1 2
{ 
Title 
=	 

title 
; 
Description 
= 
description 
; 
} 
} 
} ”
[C:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\ISpeakerValidationService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

	interface %
ISpeakerValidationService .
{ 
bool 
ValidateSpeaker 
( 
Speaker $
speaker% ,
), -
;- .
bool 
ValidateSessions 
( 
Speaker %
speaker& -
)- .
;. /
bool		 "
ValidateQualifications		 #
(		# $
Speaker		$ +
speaker		, 3
)		3 4
;		4 5
}

 
} ≤
QC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\ISpeakerService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

	interface 
ISpeakerService $
{ 
int 
? 
Register 
( 
Speaker 
speaker %
)% &
;& '
} 
}		 ≤
MC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\IFeeService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

	interface 
IFeeService  
{ 
int 
CalculateFee 
( 
int 
? 
experienceYears -
)- .
;. /
} 
} ™
LC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Services\FeeService.cs
	namespace 	

ConsoleApp
 
. 
Services 
{ 
public 

class 

FeeService 
: 
IFeeService )
{ 
public 
int 
CalculateFee 
(  
int  #
?# $
experienceYears% 4
)4 5
{ 	
int 
fee 
= 
$num 
; 
if		 
(		 
experienceYears		 
==		  "
null		# '
)		' (
{

 
return 
fee 
; 
} 
if 
( 
experienceYears 
<=  "
$num# $
)$ %
fee& )
=* +
$num, /
;/ 0
else 
if 
( 
experienceYears $
<=% '
$num( )
)) *
fee+ .
=/ 0
$num1 4
;4 5
else 
if 
( 
experienceYears $
<=% '
$num( )
)) *
fee+ .
=/ 0
$num1 4
;4 5
else 
if 
( 
experienceYears $
<=% '
$num( )
)) *
fee+ .
=/ 0
$num1 3
;3 4
return 
fee 
; 
} 	
} 
} ¿
`C:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Repositories\SqlServerCompactRepository.cs
	namespace 	

ConsoleApp
 
. 
Repositories !
{ 
public 
class &
SqlServerCompactRepository (
:) *
IRepository+ 6
{ 
public 
int	 
SaveSpeaker 
( 
Speaker  
speaker! (
)( )
{ 
return		 	
$num		
 
;		 
}

 
} 
} ¶
QC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Repositories\IRepository.cs
	namespace 	

ConsoleApp
 
. 
Repositories !
{ 
public 

	interface 
IRepository  
{ 
int 
SaveSpeaker 
( 
Speaker 
speaker  '
)' (
;( )
} 
}		 µ
@C:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Program.cs
	namespace 	

ConsoleApp
 
{ 
public 

static 
class 
Program 
{		 
public

 
static

 
void

 
Main

 
(

  
string

  &
[

& '
]

' (
args

) -
)

- .
{ 	
IRepository 

repository "
=# $
new% (&
SqlServerCompactRepository) C
(C D
)D E
;E F
IFeeService 

feeService "
=# $
new% (

FeeService) 3
(3 4
)4 5
;5 6

IValidator 
speakerValidator '
=( )
new* -
SpeakerValidator. >
(> ?
)? @
;@ A

IValidator 
sessionValidator '
=( )
new* -
SessionValidator. >
(> ?
)? @
;@ A

IValidator "
qualificationValidator -
=. /
new0 3"
QualificationValidator4 J
(J K
)K L
;L M%
ISpeakerValidationService %$
speakerValidationService& >
=? @
newA D$
SpeakerValidationServiceE ]
(] ^
speakerValidator^ n
,n o
sessionValidator	p Ä
,
Ä Å$
qualificationValidator
Ç ò
)
ò ô
;
ô ö

WebBrowser 
browser 
=  
new! $

WebBrowser% /
(/ 0
$str0 4
,4 5
$num6 7
)7 8
;8 9
Speaker 
speaker 
= 
new !
Speaker" )
() *
$str* 0
,0 1
$str2 7
,7 8
$str9 G
,G H
$strI Q
)Q R
;R S
speaker 
. 
Certifications "
." #
Add# &
(& '
$str' +
)+ ,
;, -
speaker 
. 
Sessions 
. 
Add  
(  !
new! $
Session% ,
(, -
$str- 5
,5 6
$str7 K
)K L
)L M
;M N
speaker 
. 
Browser 
= 
browser %
;% &
ISpeakerService 
speakerService *
=+ ,
new- 0
SpeakerService1 ?
(? @

repository@ J
,J K$
speakerValidationServiceL d
,d e

feeServicef p
)p q
;q r
int 
? 
id 
= 
speakerService $
.$ %
Register% -
(- .
speaker. 5
)5 6
;6 7
Console 
. 
	WriteLine 
( 
$"  
$str  (
{( )
id) +
}+ ,
$str, E
"E F
)F G
;G H
} 	
}   
}!! ∏
GC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Models\Speaker.cs
	namespace 	

ConsoleApp
 
. 
Models 
{ 
public 

class 
Speaker 
{ 
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
$str0 2
;2 3
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
$str/ 1
;1 2
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
$str		, .
;		. /
public

 
int

 
?

 
ExperienceYears

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
public 
bool 
HasBlog 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
BlogURL 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

WebBrowser 
Browser !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
default2 9
!9 :
;: ;
public 
List 
< 
string 
> 
Certifications *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 
Employer 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
$str/ 1
;1 2
public 
int 
RegistrationFee "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
List 
< 
Session 
> 
Sessions %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
Speaker 
( 
) 
{ 	
Certifications 
= 
new  
List! %
<% &
string& ,
>, -
(- .
). /
;/ 0
Sessions 
= 
new 
List 
<  
Session  '
>' (
(( )
)) *
;* +
} 	
public 
Speaker 
( 
string 
	firstName '
,' (
string) /
lastName0 8
,8 9
string: @
emailA F
,F G
stringH N
employerO W
)W X
{ 	
	FirstName 
= 
	firstName !
;! "
LastName 
= 
lastName 
;  
Email 
= 
email 
; 
Employer 
= 
employer 
;  
Certifications 
= 
new  
List! %
<% &
string& ,
>, -
(- .
). /
;/ 0
Sessions   
=   
new   
List   
<    
Session    '
>  ' (
(  ( )
)  ) *
;  * +
}!! 	
}$$ 
}%% ∆
fC:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Exceptions\SpeakerRequirementsNotMetException.cs
	namespace 	

ConsoleApp
 
. 

Exceptions 
{ 
public 

class .
"SpeakerRequirementsNotMetException 3
:4 5
	Exception6 ?
{ 
public .
"SpeakerRequirementsNotMetException 1
(1 2
string2 8
message9 @
)@ A
: 
base 
( 
message 
) 
{ 	
} 	
public

 .
"SpeakerRequirementsNotMetException

 1
(

1 2
string

2 8
message

9 @
,

@ A
	Exception

B K
inner

L Q
)

Q R
: 
base 
( 
message 
, 
inner !
)! "
{ 	
} 	
} 
} ﬂ
`C:\Personal\amdaris\1-5\amdaris-internship\ConsoleApp\Exceptions\SessionsNotApprovedException.cs
	namespace 	

ConsoleApp
 
. 

Exceptions 
{ 
public 

class (
SessionsNotApprovedException -
(- .
string. 4
message5 <
)< =
:> ?
	Exception@ I
(I J
messageJ Q
)Q R
{ 
} 
} 