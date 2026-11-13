# 프롬프트 모음집 (`design/prompt/`)

**PROJECT: TARTARUS (OMEGA PROTOCOL)** 게임 에셋 제작을 위한 **Nano Banana(2D 컨셉 시트) · Tripo 3D(모델링) · Blender(AI 자동 분할·정규화)** 통합 프롬프트 저장소입니다.

---

## 파일 구성

| 파일 | 대상 | 설명 |
|---|---|---|
| [`01_environment_3d_arena.md`](file:///home/yang/work/ai-sample/design/prompt/01_environment_3d_arena.md) | **3D 오픈스카이 아레나 환경** | 바닥·벽·오픈스카이 골조(시트 A), 수직 동선(시트 B), 장애물·엄폐물(시트 C)용 Nano Banana / Tripo / Blender 프롬프트 |
| [`02_weapons_characters_monsters.md`](file:///home/yang/work/ai-sample/design/prompt/02_weapons_characters_monsters.md) | **무기 · 캐릭터 · 몬스터 · 보스** | 기존 `prompt.md` 기반 메인 무기 5종, 캐릭터, 몬스터, 보스 생성용 프롬프트 |

---

## 권장 작업 파이프라인 (무엇을 어디에 올리는지)

| 단계 | 도구 | 올릴 것 (입력) | 결과 및 다음 단계 |
|---|---|---|---|
| **1단계** | **Nano Banana** | • **텍스트 프롬프트** (시트 A/B/C)<br>• *(선택)* 톤앤매너 통일용 기존 레퍼런스 이미지(`gun.png` 등) | 단색 회색 배경에 각 에셋이 서로 떨어져 배치된 **2D 시트 이미지** 다운로드 |
| **2단계** | **Tripo 3D** (`Image-to-3D`) | • **Nano Banana에서 받은 시트 이미지** (필수)<br>• **Tripo 보조 프롬프트** (이미지 설명/파츠 분리용) | 3D 모델 생성 후 **Tripo Bridge**로 Blender(`design/work.blend`)에 임포트 *(환경은 Auto-Rig 끄기)* |
| **3단계** | **Blender AI** (본 대화창) | • **Blender AI 프롬프트** (`01_environment_3d_arena.md` 3번 섹션) | 개별 오브젝트 분리, 중복 제거, 실측 스케일 및 바닥 피벗(`Z=0`) 정렬 후 `.blend` 저장 |

> **※ 팁**: 시트 이미지 한 장을 통째로 Tripo에 넣었을 때 파츠가 붙어서 나온다면, 시트에서 원하는 물체 1개씩만 잘라서(Crop) Tripo `Image-to-3D`에 올리거나, 이미지 없이 `4번 섹션(Text-to-3D)` 프롬프트를 사용하시면 가장 깔끔합니다.
>
> **※ 완료된 시트 크롭 및 분할 결과**:
> - 2D 시트 개별 크롭(31종): [`design/References/Cropped/`](file:///home/yang/work/ai-sample/design/References/Cropped) ([`crop_concept_sheets.py`](file:///home/yang/work/ai-sample/design/scripts/crop_concept_sheets.py), [`crop_env_sheets.py`](file:///home/yang/work/ai-sample/design/scripts/crop_env_sheets.py))
> - 환경 `.blend` 분할(15종): [`work1.blend`](file:///home/yang/work/ai-sample/design/work1.blend)~[`work3.blend`](file:///home/yang/work/ai-sample/design/work3.blend) → [`design/Environment/`](file:///home/yang/work/ai-sample/design/Environment) ([`process_environment_blends.py`](file:///home/yang/work/ai-sample/design/scripts/process_environment_blends.py))
