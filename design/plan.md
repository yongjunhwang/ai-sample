# 3D 디자인 및 에셋 제작 계획서 (`design/plan.md`)

본 문서는 **PROJECT: TARTARUS (`sample.md` 다크 SF 바이오 호러 전술 FPS)** 구현을 위한 Blender 3D 모델링, 3D 다층 수직 오픈스카이 아레나 환경, 라이팅/비전 효과, 사이버네틱 HUD 디자인 및 Unity 연동 **상세 작업 목록(WBS)**을 정의합니다.

---

## 작업 진행 현황 요약 (새 세션 기준)

| Phase | 대상 | 상태 | 비고 |
|---|---|---|---|
| **Phase 1** | 3D 환경 모듈 15종 (`Environment/`) | **모델 완료** | `work1~3.blend` 분할·스케일·`Z=0` 피벗 완료 / 라이팅·스카이박스(Unity) 대기 |
| **Phase 2** | 무기 21종 + 탄환 9종 (`Weapons/`) | **모델 완료** | 메인 5종 + 보조 16종 + 탄환 9종 (정적 메쉬 + 소켓) |
| **Phase 3** | 플레이어 아바타 6종 (`Characters/Players/`) | **리깅 완료** | 메쉬 링크 복구 + Armature + 120f `*_Combat_Idle` 적용 (`rig_all_characters_and_monsters.py`) |
| **Phase 4** | 몬스터 5종 + 보스 1종 (`Characters/Monsters/`) | **리깅 완료** | 보스(25본+Unity FBX 완료) / 일반 5종(Armature+120f `*_Combat_Idle` 완료, FBX 대기) |
| **Phase 5** | 사이버네틱 HUD & 비전 필터 (`UI/`) | **미착수** | Unity Canvas 구현 및 NVG/Thermal 볼륨 세팅 필요 |
| **Phase 6** | 오디오 & VFX | **미착수** | Unity 구매 에셋(`Weapon Soldier Sounds Pack Fps`, `100 베스트 이펙트` 등) + 외부 오디오 AI 활용 (Python `.wav` 합성 금지) |

---

## 세부 제작 목록 (Checklist)

### Phase 1: 3D 다층 수직 오픈스카이 아레나 & 환경 라이팅 (`design/Environment/`)
> 단순 2D 복도가 아닌 **고저차(수직성)와 열린 하늘(Open-Sky)**을 지원하는 3D 배틀 아레나 (보스 비행 및 상/하층 전술 사격 지원)

- [x] **1. 수직 동선 & 공중 보행로 모듈러 구조물 (`work2.blend` 분할 및 Blender 정규화 완료)**
  - [x] `SM_Catwalk_Straight_6m.blend` (길이 6.0m 격자형 철제 공중 보행로, 양측 안전 난간 포함, Z=0 정렬)
  - [x] `SM_Catwalk_Platform_4x4.blend` (4.0m × 4.0m 2층/3층 저격 및 방어용 중앙 발판, Z=0 정렬)
  - [x] `SM_Stairs_Industrial_4m.blend` (수직 4.0m 고저차 연결용 철제 지그재그 산업 계단, Z=0 정렬)
  - [x] `SM_Ramp_Access_4m.blend` (길이 6.0m 경사각 화물/차량 램프, Z=0 정렬)
  - [x] `SM_Sniper_Tower_Octa.blend` (높이 8.0m 팔각형 다층 감시 저격 타워 구조물 + 사다리 통합, Z=0 정렬)

- [x] **2. 오픈스카이 골조 & 지형/벽체 모듈 (`work1.blend` 분할 및 Blender 정규화 완료)**
  - [x] `SM_Truss_Arch_OpenSky.blend` (폭 8.0m 천장이 뚫려 하늘과 보스 비행이 노출되는 오픈 트러스 철골 아치, Z=0 정렬)
  - [x] `SM_Crater_Floor_8x8.blend` (8.0m × 7.1m 외계 암석 및 강화 금속 혼합 분화구 지면, Z=0 정렬)
  - [x] `SM_Blast_Wall_4m.blend` (높이 5.0m 외곽 경계선용 중장갑 방폭벽, Z=0 정렬)
  - [x] `SM_Blast_Wall_Doorway_4m.blend` (높이 5.0m 유압 해치 게이트형 방폭벽, 좌우 파트 통합 및 Z=0 정렬)
  - [x] `SM_Rock_Debris_Slope.blend` (높이 4.0m 점프 또는 도보로 고지대 우회가 가능한 자연 암석 슬로프 지형, Z=0 정렬)

- [x] **3. 입체 전술 엄폐물 & 공중 프랍 (`work3.blend` 분할 및 Blender 정규화 완료, 바닥면 피벗 Z=0)**
  - [x] `SM_Cover_Low_Barricade.blend` (1.93m × 0.75m × **1.0m** 앉아쏴/시야확보 전술 바리케이드)
  - [x] `SM_Cover_High_HexPillar.blend` (1.24m × 1.22m × **2.4m** 전신 은폐형 육각 서버 기둥)
  - [x] `SM_Crane_Suspended_Cargo.blend` (5.0m × 2.81m × 3.31m 공중 컨테이너 프랍)
  - [x] `SM_Cryo_Containment_Tank.blend` (2.2m × 1.15m × 1.12m 생체 발광 액체 전술 장애물 탱크)
  - [x] `SM_Debris_Rock_Mound.blend` (2.11m × 2.4m × 1.24m 암석/폐기물 엄폐 더미)

- [ ] **4. 오픈스카이 다크 SF 라이팅 & 대기 연출**
  - [ ] 개방된 상공 외계 행성 스카이박스 및 딥 네이비 지수 안개(`FogExp2`)
  - [ ] 지상 하층 저조도 앰비언트 라이트 + 2층 캣워크 시안 LED 가이드 스트립
  - [ ] 개방된 천장에서 떨어지는 지향성 메인 문라이트(Moonlight/Sunlight) 및 비상 점멸등 연출

---

### Phase 2: 무기 에셋 5종 (`gun.png` 레퍼런스 기준 — Tripo 3D 5종 분할 및 개별 `.blend` 분리 완료)
> 1인칭 시야 우하단에 배치되는 하이테크 미래형 무기군. Tripo 3D 106개 파트를 5종 무기로 공간 분할하여 정규화 및 소켓 장착 완료.

- [x] **1. `design/Weapons/Wep_ARC42_Valkyrie.blend` (ARC-42 '발키리' 전자기 가속 돌격소총 - 메인 무기, 22개 파트 통합, 0.88m, 4종 소켓 부착)**
- [x] **2. `design/Weapons/Wep_Bergelmir09_Shotgun.blend` (베르겔미르-09 중플라즈마 산탄총, 17개 파트 통합, 0.78m, 4종 소켓 부착)**
- [x] **3. `design/Weapons/Wep_KronosV_RailDMR.blend` (크로노스-V 고주파 레일 DMR, 21개 파트 통합, 1.18m, 4종 소켓 부착)**
- [x] **4. `design/Weapons/Wep_Aegis300_SmartSMG.blend` (이지스-300 분산형 스마트 SMG, 20개 파트 통합, 0.62m, 4종 소켓 부착)**
- [x] **5. `design/Weapons/Wep_HeliosX_BeamCannon.blend` (헬리오스-X 극초단파 집속 빔 캐넌, 26개 파트 통합, 1.15m, 4종 소켓 부착)**

#### 부가 무기 16종 (Secondary / Sidearm Weapons & Launchers — `design/Weapons/Secondary/`)
> 16개 개별 무기군 분할 및 `(0,0,0)` 정렬 완료 (`Wep_Sec_01.blend` ~ `Wep_Sec_16.blend`)

- [x] `Wep_Sec_01.blend` ~ `Wep_Sec_08.blend` (스나이퍼, 불펍 AR, 펄스 캐넌, 로켓 다트, 트윈 SMG, 마이크로 미사일, 블래스터 피스톨, 배틀 카빈)
- [x] `Wep_Sec_09.blend` ~ `Wep_Sec_16.blend` (마크스맨 라이플, 정밀 DMR, 골든 로켓 다트, 서브-블래스터, 컴팩트 SMG, 빔 랜스, 에너지 런처, RPG 런처)

#### 탄환 및 발사체 9종 (Bullets & Projectiles — `design/Weapons/Bullets/`)
> 9종 개별 발사체 분할 및 `(0,0,0)` 정렬 완료 (`Wep_Bullet_01.blend` ~ `Wep_Bullet_09.blend`)

- [x] `Wep_Bullet_01.blend` ~ `Wep_Bullet_09.blend` (에너지 캡슐, 키네틱 다트, 핀드 미사일, 듀얼 포드, 아틸러리 쉘, 마이크로 시커, 토피도, 플라즈마 페네트레이터, 폭발체 오브)

---

### Phase 3: 플레이어 아바타 6종 (`design/Characters/Players/`)
> 6종 개별 `.blend` 분리, 원점/소켓 정렬 + **Armature 리깅 · 스키닝 · 120f `*_Combat_Idle` 적용 완료** (`rig_all_characters_and_monsters.py`)

- [x] `SK_Player_AssaultOutrider.blend` (메인 클래스, 휴머노이드 18본)
- [x] `CH_Avatar_VanguardBreaker.blend` (돌격형, 휴머노이드 18본)
- [x] `CH_Avatar_GhostRecon.blend` (정찰 크롤러 메카, 7본)
- [x] `CH_Avatar_StrikeGear.blend` (고속 기동형, 휴머노이드 18본)
- [x] `CH_Avatar_SentinelDefender.blend` (중화기병, 휴머노이드 18본)
- [x] `CH_Avatar_Infiltrator.blend` (침투 특수병, 휴머노이드 18본)

---

### Phase 4: 몬스터 및 보스 크리처 (`design/Characters/Monsters/`)

- [x] **결전 보스 `CH_Boss_ArchDreadRaze.blend`** (`work.blend` 25본 리깅, 120f 애니메이션, Unity FBX 48,596 Tris + 4K PBR 4종 익스포트, `DragonFlightBreath.unity` 완료)
- [x] **일반 몬스터 5종 (개별 `.blend` 분리 + Armature 리깅 · 120f `*_Combat_Idle` 완료)**
  - [x] `CH_Monster_Stalker.blend` (4족 표범+꼬리, 16본)
  - [x] `CH_Monster_XenoTrooper.blend` (외계 전사, 휴머노이드 18본)
  - [x] `CH_Monster_GuardianBeast.blend` (고릴라형 비스트, 14본)
  - [x] `CH_Monster_SporeFlyer.blend` (4날개 비행 드론, 6본)
  - [x] `CH_Monster_TitanBreaker.blend` (중장갑 타이탄 거인, 휴머노이드 18본)

---

### Phase 5: 사이버네틱 HUD & 비전 필터 디자인 (`design/UI/`)
> `sample.md`의 전술 HUD 전체 구성 및 **실제 화면에서 글자가 잘리거나 세로로 줄바꿈되지 않는 레이아웃 규격**

- [ ] **1. 상단 바 (Top Header Panels)**
  - [ ] **좌측 작전 텔레메트리 패널**: `SEC-04 EXCAVATION` (시안 핑 도트), `REC [00:41:19]`, `O2: 97.4% | TEMP: -4.2°C | RAD: 14 mSv/h`, `ATMOSPHERE: CONTAMINATED / BIO-HAZARD L-4`
  - [ ] **중앙 전술 디지털 나침반**: `NW 315 | N 004° | 045 NE` (마우스 조준 연동) + `TARGET: SPECIMEN-09 EXTERMINATION`
  - [ ] **우측 근접 위협 경보 패널**: `PROXIMITY ALERT : CRITICAL`, 5칸 분할 적색 위협 게이지 바, 실시간 거리 표시(`HOSTILE TARGET / DIST: 14.2 M`)
- [ ] **2. 중앙 조준선 & 타깃 락 (Center Reticle & Target Lock)**
  - [ ] 시안 외곽 링 + 회전 점선 링 + 상하좌우 시안 발광 브래킷 + 중앙 조준 도트 + 격발 시 확장 애니메이션
  - [ ] 적색 타깃 락온 코너 브래킷 4개 + 하단 식별 배지(`LOCKED: BIOTITAN // HOSTILE`)
- [ ] **3. 하단 바 (Bottom Footer Panels - 글자 세로 깨짐/잘림 원천 방지 설계)**
  - [ ] **하단 좌측 바이탈 & 슈트 패널**:
    - `SHIELD MATRIX` 시안 그라데이션 바 (`85%`)
    - `VITALITY` 에메랄드 그라데이션 체력 바 (`100%`)
    - `BATTERY: 98% | STAMINA: OPTIMAL` 상태 표시줄
  - [ ] **하단 중앙 인터랙티브 전술 컨트롤 바 & 키 가이드**:
    - 5종 클릭/단축키 버튼: `[사격 FIRE]`, `[재장전]`, `[야간투시]`, `[열화상]`, `[택티컬 라이트]`
    - 하단 조작 키 레전드: `L-CLICK 무기 격발 | R 재장전 | N / T 투시 모드 변경 | F 라이트 | DRAG 시점 탐색`
    - **텍스트 세로 줄바꿈/잘림 방지**: 모든 버튼 및 가이드 텍스트에 `No Wrap(줄바꿈 금지)` 및 `ContentSizeFitter(Preferred Width)` + 여유 패딩(`≥16px`)을 적용해 **단 한 글자도 세로로 꺾이거나 잘리지 않도록 보장**
  - [ ] **하단 우측 30M 레이더 미니맵 & 탄약 매트릭스**:
    - **30M 전술 레이더 (`RADAR 30M RANGE`)**: 동심원 그리드, 360도 회전 스윕 라인, 플레이어 중앙 시안 도트, 몬스터 적색 핑 블립
    - **무기 탄약 매트릭스**: `PULSE CARBINE | FULL-AUTO`, 대형 네온 잔탄 카운터(`36 / 45`), 잔탄 게이지 바(25% 미만 시 적색 전환), `MAG: 4/4 | TYPE: KINETIC-PL`
- [ ] **4. 화면 오버레이 & 비전 모드 이펙트**
  - [ ] 비네트(`Vignette`), 스캔라인(`Scanline`), 적색 위협 테두리 점멸(`Alarm Border`)
  - [ ] **야간투시(`NVG`)** 그린 틴트 및 **열화상(`Thermal`)** 오렌지/바이올렛 틴트 오버레이

---

### Phase 6: 오디오 & VFX 에셋 (Unity 직접 임포트 기준)
> Blender(`.blend`)와는 무관하게 Unity(`development/Assets/`)에 직접 적용. **Python 합성(`.wav` 생성)은 사용하지 않음.**

- [ ] **1. 오디오 (보유 에셋 + 외부 오디오 AI)**
  - [ ] 총기/재장전/발소리: 구매 에셋 `Weapon Soldier Sounds Pack Fps` 임포트 및 매핑
  - [ ] 보스 브레스/괴수 포효/UI/BGM: 외부 오디오 AI(ElevenLabs 등)로 생성 후 Unity 배치
- [ ] **2. VFX (보유 에셋 활용)**
  - [ ] 보스 플라즈마 브레스, 총구 화염, 탄궤적, 피격 이펙트: 구매 에셋(`100 베스트 이펙트 패키지`, `Rocket Trail VFX pack`, `Hit Impact Effects FREE` 등) 적용
  - [ ] `SFX_Ambience_ExcavationRoom.wav` (지하 발굴 기지 저주파 룸톤 및 비상 경보음)
  - [ ] 이동/자세 전환 발소리 (`Stand`, `Crouch`, `Prone`) 및 재질별 피탄음 (`Concrete`, `Metal`, `Flesh`)
