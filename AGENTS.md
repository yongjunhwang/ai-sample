# 작업 지침

- 사용자 요청 우선. 하위 `AGENTS.md`도 확인. 설명과 결과는 한국어로 짧게.
- Unity 프로젝트: `development/`. Blender 원본: `design/work.blend`.
- 기존 작업과 파일을 보존. 관련 없는 수정, Git 초기화·커밋·푸시는 요청 없이 하지 않기.

## 새 대화 시작

1. 대상이 정해지지 않았으면 아래 질문만 하고 답변 기다리기. 작업이나 폴더로 추측하지 않기.
   > 어디에 연결할까요? Unity(`development`), Blender(`design`), 전부 중 하나를 선택해주세요.
2. 선택한 대상의 주소를 하나씩 확인. 전부면 Unity → Blender 순서.
   > Unity MCP 주소를 기본값(`http://localhost:8080/mcp`)으로 할까요? Y 또는 사용할 주소를 입력해주세요.
   > Blender 애드온 주소를 기본값(`127.0.0.1:9876`)으로 할까요? Y 또는 사용할 주소를 입력해주세요.
3. 모든 주소가 정해지면 연결 검증. 결과 보고 후 원래 요청 계속하기.

- 대상: Unity/development/1, Blender/design/2, 전부/둘 다/모두/both/all/3. 영문 대소문자 무관.
- 기본값 승인: 네/에/예/yes/y/기본값/기본 주소 사용. 앞뒤 공백과 끝 문장부호 허용. 애매하면 다시 묻기.
- 대상 선택은 주소 승인이 아님. 현재 대화에서 확정한 대상·주소는 다시 묻지 않기.
- 이미 지정한 항목은 질문 생략. 시작 절차 생략 요청은 따르기. 누락한 질문은 다음 응답에서 하기.
- 첫 메시지부터 적용하며 질문 단계에서는 도구 호출 금지. CLI 초기 프롬프트도 첫 메시지로 취급.

## 연결 검증

- 선택한 대상만 읽기 전용으로 점검. 씬 수정, 저장, 재로드, Play Mode 금지.
- 등록 설정과 실제 접속 주소를 대조. 설정만으로 연결 성공을 판단하지 않기.
- 같은 로컬 서버의 localhost와 127.0.0.1은 동일하게 취급.
- 주소 변경을 적용할 수 없으면 설정 변경·세션 재시작 필요 여부 안내.
- 모두 통과하면 `준비되었습니다.`로 시작해 주소·버전·경로·씬 보고.
- 하나라도 실패하거나 미확인이면 `실패했습니다.`로 시작해 원인·조치 보고.
- 전부 선택 시 한쪽이 실패해도 양쪽 점검. 정상 대상의 작업은 계속하고 실패한 연결이 필요한 작업은 보류.

### Unity

- `unity-mcp-orchestrator` 스킬 적용. 도구 노출과 `codex mcp get unityMCP --json` 주소 확인. 스킴이 없으면 `http://` 사용.
- `mcpforunity://instances` 조회. 여러 인스턴스면 프로젝트 경로를 확인하고 `set_active_instance`로 고정.
- `mcpforunity://project/info`의 `projectRoot`와 `development/`의 실제 경로 비교. 심볼릭 링크를 해석하고 `Assets`, `Packages`, `ProjectSettings` 존재 확인.
- `mcpforunity://custom-tools`, `mcpforunity://editor/state` 조회. 도구가 없으면 커스텀 도구·비활성 그룹 확인.
- `ready_for_tools`, 컴파일·리로드 상태 확인 후 `manage_scene(get_active)` 실제 호출. 일시적인 대기 상태는 재확인.

### Blender

- `design/AGENTS.md` 확인. `blender` MCP 우선 사용.
- `codex mcp get blender --json`과 서버 기본값·실제 접속을 확인. 주소는 HTTP가 아닌 `호스트:포트`.
- 씬 조회와 Python으로 응답, `bpy.app.version_string`, 현재 씬, `bpy.data.filepath` 확인.
- 실제 파일 경로가 `design/work.blend` 또는 사용자가 지정한 파일과 같은지 확인. 미저장·불일치·미확인은 실패.
- 둘 다 선택하고 Unity 검증에 성공했다면 `blender_bridge` 대체 사용 가능. 주소도 검증.

## 개발·검증

- 관련 파일과 참조부터 확인. Unity 검색은 `development/Assets`, `Packages`, `ProjectSettings` 중심으로 제한.
- 코드뿐 아니라 씬·컴포넌트·Inspector·프리팹·UI 연결까지 완료. 자동화 재실행 시 중복·덮어쓰기 방지.
- 변경에 맞는 검증 수행. 미실행 항목과 이유, 필요한 수동 조작을 짧게 보고. 확인하지 않은 성공은 보고하지 않기.
- 비밀 키·토큰·개인 경로 하드코딩 금지. 검증 산출물은 에셋 밖에 보관.
