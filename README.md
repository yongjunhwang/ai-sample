# Unity + Codex / Claude Code 설정 안내

이 프로젝트에서 Codex 또는 Claude Code가 Unity Editor와 연결되어 작업하도록 준비하는 방법입니다. 1~5장은 Codex 기준이며, Claude Code는 [6장](#6-claude-code-설정)에 차이점만 정리했습니다. 명령 예시는 Linux의 Bash 기준입니다. (MacOS 호환될 것이나, window 에서는 설정 필요)

## 1. 현재 프로젝트 기준

2026-10-25에 확인한 환경입니다. 다른 PC에서는 설치 상태를 다시 확인하세요.
다른 PC 에서 unity 버전이나 codex, claude 버전을 변경해 사용해도 문제 없습니다. 하지만 조금 다를 수 있으니 주의 필요

- Unity: `2022.3.62f3` (`ProjectSettings/ProjectVersion.txt` 기준)
- Codex CLI: `0.164.0`
- 프로젝트 경로: `/home/yang/work/unity/ai-sample`
- 활성 씬: `Assets/Scenes/SampleScene.unity`
- 기본 MCP 주소: `http://localhost:8080/mcp`
- 실제 등록 주소: `http://127.0.0.1:8080/mcp` — 이 환경에서는 같은 로컬 서버로 취급

MCP 패키지의 현재 의존성은 다음과 같습니다.

```json
"com.coplaydev.unity-mcp": "https://github.com/CoplayDev/unity-mcp.git?path=/MCPForUnity#main"
```

현재 `Packages/packages-lock.json`에 기록된 커밋은 `81542a7e86292b5c4c21b1782c5af23b567f45ce`입니다. `main`은 변경될 수 있으므로 새 설치 환경이 현재 환경과 항상 같지는 않습니다. 기존 manifest와 lock 파일을 함께 보존하세요.

## 2. 최초 준비

### 2-1. Codex CLI 준비

Codex CLI가 없는 PC에서는 [공식 설치 안내](https://developers.openai.com/codex/quickstart)를 따라 설치하고 로그인합니다. 이미 사용하는 PC에서는 다음으로 실행 가능 여부를 확인합니다.

```bash
codex --version
codex --help
```

현재 PC에서는 CLI가 설치되어 있어 재설치할 필요가 없습니다.

### 2-2. Unity 프로젝트 열기

1. Unity Hub에서 이 프로젝트 폴더를 추가합니다.
2. `ProjectSettings/ProjectVersion.txt`와 같은 버전의 Editor로 엽니다.
3. 패키지 가져오기와 스크립트 컴파일이 끝날 때까지 기다립니다.
4. Console에 컴파일 오류가 있으면 먼저 해결합니다.
5. `Assets/Scenes/SampleScene.unity`를 엽니다.

이 프로젝트에는 MCP 패키지 의존성이 이미 있으므로 중복으로 추가하지 않습니다. 별도의 새 프로젝트를 구성할 경우 Unity Package Manager의 Git URL 추가 기능에서 위 의존성 URL을 사용합니다.

### 2-3. Unity MCP 서버와 Bridge 시작

설치된 패키지의 Editor 안내에 따른 순서입니다. 패키지 버전에 따라 버튼 이름과 배치가 달라질 수 있습니다.

1. Unity 메뉴에서 **Window > MCP for Unity**를 엽니다.
2. Python 또는 `uv`/`uvx`가 없다는 안내가 있으면 창의 설치 안내를 따릅니다.
3. HTTP 연결을 사용할 수 있도록 설정하고 서버 URL과 포트를 확인합니다. 이 프로젝트의 기본 접속 주소는 `http://localhost:8080/mcp`입니다.
4. 서버가 실행되지 않았다면 **Start Local HTTP Server**를 사용합니다. 창의 **HTTP Server Command**에서 실제 실행 명령을 확인할 수 있습니다.
5. Unity Bridge가 중지 상태라면 **Start Bridge**를 누릅니다.
6. 서버 실행 상태와 Bridge 연결 상태를 확인합니다.

이미 서버가 실행 중이라면 같은 포트에 서버를 추가로 띄우지 않습니다. Codex에 URL을 등록하는 것은 서버를 시작하는 작업과 별개입니다.

### 2-4. Codex에 MCP 주소 등록

먼저 현재 등록 상태를 확인합니다.

```bash
codex mcp get unityMCP --json
```

등록되어 있지 않을 때 다음 명령으로 추가합니다.

```bash
codex mcp add unityMCP --url http://localhost:8080/mcp
```

명령 형식은 현재 설치된 CLI의 `codex mcp add --help`로 확인했습니다. 현재 PC에는 동등한 주소인 `http://127.0.0.1:8080/mcp`가 이미 등록되어 있으므로 다시 추가할 필요가 없습니다.

직접 설정 파일을 관리할 경우의 TOML 예시는 다음과 같습니다. 기존 설정에 같은 이름의 테이블이 있으면 중복 추가하지 말고 해당 항목을 수정합니다.

```toml
[mcp_servers.unityMCP]
url = "http://localhost:8080/mcp"
```

일반적인 사용자 설정 파일은 `~/.codex/config.toml`입니다. 사용자 지정 `CODEX_HOME`을 사용하는 환경에서는 설정 위치가 달라질 수 있습니다. 실제 적용 주소는 `codex mcp get unityMCP --json`으로 확인하세요.

설정을 새로 등록하거나 변경한 뒤에는 Codex 세션을 다시 시작하여 MCP 도구가 로드되는지 확인합니다.

### 2-5. Unity 스킬 준비

이 프로젝트의 `AGENTS.md`는 연결 점검 시 `unity-mcp-orchestrator` 스킬을 사용하도록 지정합니다. 현재 환경의 파일 위치는 다음과 같습니다.

```text
~/.codex/skills/unity-mcp-skill/SKILL.md
```

다른 PC로 옮길 때 프로젝트만 복사하면 이 사용자 디렉터리의 스킬은 함께 이동하지 않습니다. 현재 사용하는 스킬을 이전하려면 `SKILL.md`와 `references/` 등 지원 파일이 포함된 `unity-mcp-skill` 폴더 전체를 함께 설치해야 합니다. Codex를 다시 시작한 뒤 사용 가능한 스킬 목록에 `unity-mcp-orchestrator`가 표시되는지 확인합니다.

스킬은 도구 사용 절차를 안내합니다. 스킬 파일만 설치해도 MCP 서버나 Unity 패키지가 설치되는 것은 아닙니다.

## 3. 매일 작업을 시작하는 방법

먼저 Unity 프로젝트를 열고 MCP 서버와 Bridge가 연결된 상태인지 확인합니다. 이어서 프로젝트 루트에서 Codex를 실행합니다.

```bash
cd /home/yang/work/unity/ai-sample
codex
```

다른 PC에서는 `cd` 경로를 실제 프로젝트 위치로 바꿉니다.

첫 메시지로 작업을 요청하면 `AGENTS.md`에 따라 Codex가 먼저 다음 질문을 합니다.

> Unity MCP 주소를 기본값(`http://localhost:8080/mcp`)으로 하시겠습니까? 네/에/예/yes/Y로 답하거나, 사용할 주소를 입력해주세요.

기본 주소라면 `Y`라고 답합니다. 다른 주소라면 주소 전체를 입력합니다. 이 확인은 새 대화마다 필요하며 같은 대화에서 이미 확정한 주소는 다시 묻지 않습니다.

실행과 동시에 시작 절차를 요청하려면 초기 프롬프트를 전달합니다.

```bash
codex 'AGENTS.md의 시작 절차를 수행하고 Unity MCP 주소부터 질문해줘.'
```

이 명령 자체는 기본 주소 사용 승인이 아닙니다. 질문을 받으면 별도로 답합니다. 반대로 첫 요청에 주소를 명확히 지정하면 주소 질문을 생략하고 연결 검증을 수행합니다.

```bash
codex 'Unity MCP 주소는 http://localhost:8080/mcp 를 사용하세요. 연결 준비 상태를 확인해주세요.'
```

`AGENTS.md`는 CLI 시작 훅이 아닙니다. `codex`만 실행하고 메시지를 보내지 않은 상태에서 자동 질문 화면을 띄우는 기능은 제공하지 않습니다.

## 4. 연결 성공을 판단하는 기준

주소를 승인한 후 Codex는 다음을 확인합니다.

1. 등록 주소가 사용자 지정 주소와 일치하는지 확인합니다.
2. `mcpforunity://instances`로 실제 연결된 Editor를 조회합니다. 여러 인스턴스가 있으면 대상 프로젝트를 확인해 고정합니다.
3. `mcpforunity://project/info`의 `projectRoot`가 현재 프로젝트의 실제 경로와 같은지 확인합니다.
4. `mcpforunity://custom-tools`와 `mcpforunity://editor/state`를 읽습니다.
5. `ready_for_tools`가 참이고 컴파일·도메인 리로드가 진행 중이지 않은지 확인합니다.
6. `manage_scene`의 `get_active`처럼 읽기 전용 도구를 호출하여 실제 Editor 응답을 확인합니다.

이 URI들은 Codex가 MCP 리소스 읽기로 접근하는 식별자입니다. 브라우저에 입력하는 웹 주소가 아닙니다.

모든 단계가 성공하면 `준비되었습니다.`로 시작하는 결과가 나옵니다. 실패하면 `실패했습니다.`와 함께 실패 단계 및 필요한 조치를 안내합니다. 연결 점검에는 Play Mode 진입이나 씬 수정이 필요하지 않습니다.

## 5. 주소 변경 및 오류 해결

| 증상 | 확인 및 조치 |
| --- | --- |
| `unityMCP` 등록을 찾을 수 없음 | `codex mcp add unityMCP --url ...`로 등록한 뒤 새 세션을 시작합니다. |
| MCP 도구가 표시되지 않음 | 등록 상태, 서버 실행 상태, Codex 시작 시 연결 오류를 확인하고 세션을 재시작합니다. |
| 서버 연결 거부 또는 시간 초과 | Unity MCP 창에서 HTTP 서버 실행 여부와 실제 포트를 확인합니다. |
| 서버는 응답하지만 Editor 인스턴스가 없음 | Unity Editor가 열려 있는지, Bridge가 서버에 연결되어 있는지 확인합니다. |
| 다른 프로젝트에 연결됨 | 프로젝트 이름만 보지 말고 `projectRoot`를 비교한 뒤 올바른 인스턴스를 선택합니다. |
| 컴파일·리로드 중으로 준비되지 않음 | 완료를 기다립니다. 지속되면 Unity Console의 오류를 확인합니다. |
| 스킬을 찾을 수 없음 | 사용자 스킬 폴더와 지원 파일을 설치한 뒤 새 세션에서 목록을 확인합니다. |
| 주소를 답했지만 이전 서버로 연결됨 | 대화 중 주소 지정과 MCP 등록은 별개입니다. 설정의 URL을 수정하고 세션을 다시 시작합니다. |

주소를 바꿀 때는 먼저 Unity MCP 서버가 새 주소에서 실행되도록 준비하고, Codex 설정의 기존 `[mcp_servers.unityMCP]` 항목에서 `url`을 수정합니다. `codex mcp get unityMCP --json`으로 변경을 확인한 뒤 새 세션에서도 해당 주소를 지정합니다.

`localhost`는 Codex 프로세스가 실행되는 환경을 가리킵니다. Codex와 Unity가 서로 다른 PC나 컨테이너에서 실행되면 같은 주소가 같은 서버를 가리킨다고 가정하지 말고 실제 접근 가능한 주소를 사용하세요.

## 6. Claude Code 설정

Unity 쪽 준비(2-2, 2-3)와 시작·검증 절차(3~4장)는 Codex와 같습니다. 다른 점만 적습니다.

- **지침:** `CLAUDE.md`, `.claude/CLAUDE.md`가 `AGENTS.md`를 가리키는 심볼릭 링크이므로 `AGENTS.md`만 수정합니다.
- **MCP 등록:** 프로젝트 루트에서 실행합니다. `--transport http`를 빼면 stdio로 등록됩니다.

  ```bash
  claude mcp get UnityMCP   # 등록 확인
  claude mcp add --transport http UnityMCP http://localhost:8080/mcp
  ```

  주소 변경은 `claude mcp remove UnityMCP -s local` 후 다시 추가합니다. 변경 후 세션을 재시작하고 `/mcp`에서 connected인지 확인합니다.
- **스킬:** `~/.claude/skills/unity-mcp-skill/` 에 폴더 전체를 설치합니다.
- **실행:** 프로젝트 루트에서 `claude`를 실행합니다.

## 7. 이번 문서 작성 시 확인 범위

- 실제 MCP 등록 주소, Editor 인스턴스, 프로젝트 경로, Unity 버전을 확인했습니다.
- Editor가 도구 사용 준비 상태이고 컴파일·도메인 리로드 중이 아님을 확인했습니다.
- 활성 씬을 읽기 전용 MCP 도구로 조회했습니다.
- CLI 버전과 MCP 등록 명령 도움말, 패키지 manifest 및 lock 정보를 확인했습니다.
- Claude Code(`2.1.310`)의 MCP 등록 상태와 연결 검증을 확인했습니다.
- 새 PC에서의 전체 재설치, Play Mode 테스트, 플레이어 빌드는 수행하지 않았습니다.

프로젝트 개발 규칙과 시작 절차의 기준 문서는 [AGENTS.md](AGENTS.md)입니다.

## Q&A

### AGENTS.md만 있으면 설정이 끝나나요?

아닙니다. `AGENTS.md`는 Codex가 따라야 할 프로젝트 작업 지침입니다. MCP 서버 등록, 서버 실행, Unity 패키지 설치 및 스킬 설치는 별도로 필요합니다.

| 구성 요소 | 역할 | 현재 확인한 상태 |
| --- | --- | --- |
| `AGENTS.md` | 한국어 응답, 주소 질문, 연결 검증, Unity 개발 규칙 | 프로젝트 루트에 있음 |
| `README.md` | 사람이 따라 할 설치·실행 안내 | 이 문서 |
| `~/.codex/config.toml` | 사용자 단위 Codex 설정 | 파일 존재 확인 |
| `.codex/config.toml` | 프로젝트 단위 Codex 설정 | 현재 없음 |
| Codex의 `unityMCP` 등록 | 접속할 MCP 서버 주소 지정 | `http://127.0.0.1:8080/mcp` |
| `unity-mcp-orchestrator` 스킬 | Unity 도구와 리소스를 사용하는 절차 | 현재 세션에서 사용 가능 |
| Unity의 MCP for Unity 패키지 | Editor와 MCP 서버 사이의 연동 | `Packages/manifest.json`에 등록됨 |
| 실행 중인 MCP 서버와 Unity Editor | 실제 요청 처리 | 현재 대화에서 조회 성공 |

`README.md`를 작성하거나 `AGENTS.md`에 주소를 적는 것만으로 MCP가 등록되지는 않습니다. 주소 질문에 답하는 것도 접속 대상 확인 절차이며, 저장된 연결 설정을 자동 변경하는 명령은 아닙니다.

Codex의 프로젝트 지침과 설정 파일에 대한 설명은 [AGENTS.md 공식 안내](https://learn.chatgpt.com/docs/agent-configuration/agents-md)와 [설정 레퍼런스](https://learn.chatgpt.com/docs/config-file/config-reference)를 참고하세요.
