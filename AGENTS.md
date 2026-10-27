# 작업 지침

- 사용자 요청 우선. 하위 `AGENTS.md`도 확인. 설명과 결과는 한국어로 짧게.
- Unity 프로젝트: `development/`. Blender 원본: `design/work.blend`.
- 기존 작업과 파일을 보존. 관련 없는 수정, Git 초기화·커밋·푸시는 요청 없이 하지 않기.

## 새 대화 시작

1. 대상이 정해지지 않았으면 아래 질문만 하고 답변 기다리기. 작업이나 폴더로 추측하지 않기.
   > 어디에 연결할까요? Unity(`development`), Blender(`design`), 전부 중 하나를 선택해주세요.
2. 선택한 대상의 MCP 등록 여부 확인(`## MCP 설치 확인`). 미등록이면 설치 여부를 묻고 답변 기다리기.
3. 모든 주소가 정해지면 연결 검증. 결과 보고 후 원래 요청 계속하기.

- 대상: Unity/development/1, Blender/design/2, 전부/둘 다/모두/both/all/3. 영문 대소문자 무관.
- Unity MCP(`http://localhost:8080/mcp`), Blender(`http://127.0.0.1:9876`) 으로 주소 설정.
- 이미 지정한 항목은 질문 생략. 시작 절차 생략 요청은 따르기. 누락한 질문은 다음 응답에서 하기.
- 첫 메시지부터 적용하며 질문 단계에서는 도구 호출 금지. CLI 초기 프롬프트도 첫 메시지로 취급.

## MCP 설치 확인

1. 선택한 대상만 등록 여부 확인. 읽기 전용: `codex mcp get <이름> --json`(Codex), `claude mcp get <이름>`(Claude Code), `~/.gemini/antigravity/mcp_config.json`의 `mcpServers.<이름>` 조회(Antigravity). 현재 도구에 맞는 쪽만 사용.
   - Unity: `unityMCP`, Blender: `blender`
2. 이미 등록되어 있으면 질문 없이 다음 단계로 진행.
3. 미등록이면 설치할 명령을 보여주고 승인을 묻기. 답변 전에는 설치하지 않기.
   > `unityMCP` MCP가 설치되어 있지 않습니다. 설치할까요? Y/예/승인 등을 입력하면 설치하고, 아니면 건너뜁니다.
   > `blender` MCP가 설치되어 있지 않습니다. 설치할까요? Y/예/승인 등을 입력하면 설치하고, 아니면 건너뜁니다.
4. 승인하면 아래 명령으로 설치. 전부면 Unity → Blender 순서로 각각 확인.
5. 설치 후 `get`으로 등록 확인. 등록 직후에는 도구가 노출되지 않으므로 CLI 세션 재시작 필요 여부 안내.
6. 거절하면 해당 대상 작업은 보류하고 연결 검증은 `실패했습니다.`(미설치)로 보고. 다른 대상은 계속 진행.

| 대상 | Codex | Claude Code |
| --- | --- | --- |
| Unity | `codex mcp add unityMCP --url http://localhost:8080/mcp` | `claude mcp add --transport http --scope user unityMCP http://localhost:8080/mcp` |
| Blender | `codex mcp add blender -- uvx mcp-for-blender` | `claude mcp add --transport stdio --scope user blender -- uvx mcp-for-blender` |

**Antigravity**: CLI 명령이 없으므로 `~/.gemini/antigravity/mcp_config.json`의 `mcpServers`에 항목을 추가. 파일이 없으면 새로 만들고, 있으면 기존 서버 항목은 그대로 두고 병합(쓰기 전 내용 확인, 유효한 JSON 유지).

```json
{
  "mcpServers": {
    "unityMCP": { "serverUrl": "http://localhost:8080/mcp" },
    "blender": { "command": "uvx", "args": ["mcp-for-blender"] }
  }
}
```

- Antigravity는 설정 반영을 위해 MCP 서버 새로고침 또는 재시작 필요(Agent 패널 > MCP Servers > Manage). 안내만 하기.
- Unity 주소는 `연결 변경`에서 정한 값으로 대체. Blender는 `uvx`가 필요하므로 없으면 설치하지 않고 안내만.
- 서버 등록만 수행. Unity 패키지·Blender 애드온 설치와 서버 시작은 README 안내대로 사용자가 직접 하도록 안내.
- 사용자 범위 설정 변경이므로 승인 없이 등록·수정·삭제 금지.

## 연결 변경

1. mcp 연결 변경 요청이 있으면 unity 혹은 blender 연결을 변경한다.
2. unity, blender, 혹은 모두 중에 어떤 주소를 변경할지 묻는다.
   > 어디 주소를 변경할까요? Unity(`development`), Blender(`design`), 전부 중 하나를 선택해주세요.
3. 선택한 대상의 주소를 하나씩 확인. 전부면 Unity → Blender 순서.
   > Unity MCP 주소를 기본값(`http://localhost:8080/mcp`)으로 할까요? Y/예/승인 등을 입력해 주세요. 그게 아니라면 접속할 주소를 입력해주세요.
   > Blender 애드온 주소를 기본값(`http://127.0.0.1:9876`)으로 할까요? Y/예/승인 등을 입력해 주세요. 그게 아니라면 접속할 주소를 입력해주세요.
4. 선택한 대상이 미등록이면 `## MCP 설치 확인` 적용.
5. 모든 주소가 정해지면 연결 검증. 결과 보고 후 원래 요청 계속하기.

- 대상: Unity/development/1, Blender/design/2, 전부/둘 다/모두/both/all/3. 영문 대소문자 무관.
- 접속 default 는 Unity MCP(`http://localhost:8080/mcp`), Blender(`http://127.0.0.1:9876`) 으로 주소 설정.
- 기본값 승인: 네/에/예/yes/y/승인/승/기본값/기본 등 동의함 확인. 애매하면 다시 묻기.
- 대상 선택은 주소 승인이 아님. 현재 대화에서 확정한 대상·주소는 다시 묻지 않기.
- 이미 지정한 항목은 질문 생략. 시작 절차 생략 요청은 따르기. 누락한 질문은 다음 응답에서 하기.

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
- Unity와 Blender는 각각 직접 MCP 연결 사용. 사용자의 명시적인 활성화 요청이 없으면 `blender_bridge`를 활성화하지 않기.

## 개발·검증

- 관련 파일과 참조부터 확인. Unity 검색은 `development/Assets`, `Packages`, `ProjectSettings` 중심으로 제한.
- 코드뿐 아니라 씬·컴포넌트·Inspector·프리팹·UI 연결까지 완료. 자동화 재실행 시 중복·덮어쓰기 방지.
- 변경에 맞는 검증 수행. 미실행 항목과 이유, 필요한 수동 조작을 짧게 보고. 확인하지 않은 성공은 보고하지 않기.
- 비밀 키·토큰·개인 경로 하드코딩 금지. 검증 산출물은 에셋 밖에 보관.
