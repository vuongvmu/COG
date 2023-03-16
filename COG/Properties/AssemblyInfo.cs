using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 어셈블리의 일반 정보는 다음 특성 집합을 통해 제어됩니다.
// 어셈블리와 관련된 정보를 수정하려면
// 이 특성 값을 변경하십시오.
[assembly: AssemblyTitle("COG")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("COG")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corporation 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible을 false로 설정하면 이 어셈블리의 형식이 COM 구성 요소에 
// 표시되지 않습니다. COM에서 이 어셈블리의 형식에 액세스하려면 
// 해당 형식에 대해 ComVisible 특성을 true로 설정하십시오.
[assembly: ComVisible(false)]

// 이 프로젝트가 COM에 노출되는 경우 다음 GUID는 typelib의 ID를 나타냅니다.
[assembly: Guid("667f79fa-c4ae-4702-be21-61052345630c")]

// 어셈블리의 버전 정보는 다음 네 가지 값으로 구성됩니다.
//
//      주 버전
//      부 버전 
//      빌드 번호
//      수정 버전
//
// 모든 값을 지정하거나 아래와 같이 '*'를 사용하여 빌드 번호 및 수정 버전이 자동으로
// 지정되도록 할 수 있습니다.
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230210

// 내용 : Program 시연 및 리뷰 내용 적용

// 상세 내용
// ** 아래 내용 중 몇몇 아이템은 ATT 및 CGMS 빌드에 따라 동적 변경됨
// 1. Device Protocol Data 제거 및 Xml Managing
// 2. Recipe Class 구현
// 3. UI 수정 및 UI 계층 변경
// 4. CGMS 向 Main Viewer 및 Logo 변경
// 5. PLC Interface 수정 ( CCLink )


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230207

// 내용 : Bead Tool OCX 추가

// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230202

// 내용 : Inpsection Item 3종 추가

// 상세 내용
// 1. Measure 검사 - Caliper & Circle 사용
// 2. Particle 검사 - Blob 사용
// 3. Short 검사 - Bead 사용


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230201

// 내용 : 솔루션 내 프로젝트 트리 변경

// 상세 내용
// 1. 솔루션 경로의 Dll 폴더에서 DLL 관리
// 2. 빌드이벤트 추가 : Dll -> Runtime Copy


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230131

// 내용 : [구조변경] Vision Teaching Item 순차 기능

// 상세 내용
// 1. 기존 Teaching Dialog Form에서 Mark Register, Align, Akkon Teaching 모두 진행
// 2. Auto Focus, Mark Register, Align, Akkon Teaching 각 각 UserControl 구성


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20230113

// 내용 : [구조변경] Teaching Point 동적할당

// 상세 내용
// 1. Teaching Position 동적 할당
// 2. Teaching Position에 따라 Motion Property 적용되도록 수정
// 3. Teaching Data 및 Motion Property 구조 생성 및 변경


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20221101 ~

// 내용 : 표준화 작업 및 구조변경

// 상세 내용
// 1. 기존 Form에 산개된 Control 제거 및 UserControl화 진행 중


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20221013

// 내용 : [구조변경] AlignUnit 관련 Indexing 밀어넣기

// 상세 내용
// 1. Define을 사용하기 위해 Indxing 밀어넣기
// 2. 각 Indexing에 들어갈 Define은 수정하지 않음


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20220925

// 내용 : Main UI 동적할당

// 상세 내용
// 1. Stage, Tab 갯수에 따라 Main UI 동적 할당


// -------------------------------------------------- Modify --------------------------------------------------
// 날짜 : 20220911

// 내용 : [구조변경] 인터페이스 구현

// 상세 내용
// 1. 카메라 및 모션 관련 인터페이스 구현