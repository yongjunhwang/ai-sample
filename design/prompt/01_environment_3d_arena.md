# 3D 다층 수직 오픈스카이 아레나 환경 프롬프트 (`01_environment_3d_arena.md`)

**톤앤매너**: 다크 SF 바이오 호러 전술 FPS (`SEC-04 Excavation Crater`)
**핵심 컬러 팔레트**:
- 주조색(Base): 다크 건메탈 / 딥 네이비 스틸 (`#0f131a`, `#181c24`)
- 발광 포인트(Emissive): 시안 네온 (`#06b6d4`), 바이오 호러 경보 레드 (`#ff1e1e`)
- 보조 디테일: 경고 노랑 해저드 스트라이프, 웨더링/스크래치

---

## 0. 맵 제작 필수 에셋 체크리스트 (바닥 · 배경 · 벽 · 수직 동선 · 장애물)

1. **바닥 (Floor / Terrain)**
   - 강화 메탈 분화구 지면 타일 (`8m × 8m` 모듈)
   - 2~3층 공중 플랫폼 바닥 (`4m × 4m`)
2. **벽 & 경계 (Walls & Perimeter)**
   - 외곽 방폭벽 (`4m × 5m`) — 직선벽, 유압식 해치 출입구벽
   - 자연 암석 절벽/옹벽 (`Rock Slope`)
3. **배경 & 오픈스카이 골조 (Background & Open-Sky)**
   - 오픈 트러스 철골 아치 (`8m × 6m`, 지붕 없음 — 보스 비행/하늘 노출)
   - *(스카이박스·안개·조명은 Unity 환경에서 구성)*
4. **수직 동선 (Vertical Connectors)**
   - 2층 공중 캣워크(`6m × 2m`, 양측 1.1m 난간), 4m 수직 계단, 30도 경사로(램프), 팔각 저격 타워(`8m`)
5. **장애물 & 엄폐물 (Obstacles & Cover)**
   - 하프 엄폐물(`높이 1.0m` 전술 바리케이드 — 앉아쏴)
   - 풀 엄폐물(`높이 2.4m` 육각 서버 기둥 — 전신 은폐)
   - 생체 배양 탱크, 공중 크레인 컨테이너, 바위 잔해 더미

---

## 1. Nano Banana 프롬프트 (2D 컨셉 시트 생성용)

> Tripo `Image-to-3D` 변환 시 파츠 뭉개짐을 방지하기 위해 **3개 시트**로 나누어 생성합니다.

### [시트 A] 바닥 · 방폭벽 · 오픈스카이 골조
```text
Concept art asset sheet of sci-fi dark bio-horror industrial modular arena environment, isolated 3D game assets neatly arranged in a grid on a clean solid neutral gray background, isometric orthographic view:
1. Heavy reinforced steel crater floor tile (square 8x8m scale) with industrial metal grating and alien dark rock edges,
2. Heavy armored blast wall panel (4m wide, 5m tall) with weathered gunmetal plating, yellow hazard stripes, and horizontal cyan neon LED strip,
3. Blast wall with central hydraulic bulkhead doorway frame,
4. Massive open-sky structural steel truss arch framework (hollow scaffolding, no roof panel),
5. Jagged dark alien rock cliff slope module for arena perimeter.
Dark navy and gunmetal matte metal (#0f131a, #181c24), glowing cyan accents (#06b6d4), weathered scratches, Unreal Engine 5 game asset style, sharp edges, wide spacing between each item --no shadows on background, no text, no overlapping
```

### [시트 B] 수직 동선 (캣워크 · 계단 · 램프 · 타워)
```text
Concept art asset sheet of sci-fi vertical multi-level arena connectors, isolated 3D game assets neatly arranged in a grid on a clean solid neutral gray background, isometric orthographic view:
1. Elevated steel catwalk bridge (6m long, 2m wide) with see-through metal grating and 1.1m safety railings with cyan LED strip,
2. Square elevated catwalk platform (4x4m) with corner support brackets,
3. Heavy industrial steel zigzag staircase (4m height rise) with yellow safety handrails,
4. 30-degree inclined cargo access ramp with anti-slip tread grooves and cyan side guide lights,
5. Octagonal multi-tiered tactical sniper lookout tower with comm antenna and red warning beacon.
Dark sci-fi bio-horror industrial aesthetic, matte dark charcoal metal, cyan (#06b6d4) and hazard yellow accents, clean separation between items --no shadows on background, no text, no overlapping
```

### [시트 C] 전술 장애물 & 엄폐물
```text
Concept art asset sheet of sci-fi tactical cover props and obstacles, isolated 3D game assets neatly arranged in a grid on a clean solid neutral gray background, isometric orthographic view:
1. Low tactical half-cover barricade (1.8m wide, 1.0m tall), angled ballistic armor plates with bullet scuffs and cyan indicator light,
2. Tall hexagonal full-cover server pillar (1.2m wide, 2.4m tall) with thick hydraulic cables and warning decals,
3. Cylindrical cryogenic bio-containment tank obstacle with glowing red/orange bio-fluid core inside glass tube,
4. Heavy suspended industrial cargo container obstacle with crane hook mounts on top,
5. Clustered dark metallic debris and alien rock cover mound.
Dark cyberpunk bio-horror facility mood, weathered gunmetal, brushed steel, cyan (#06b6d4) and bio-hazard red (#ff1e1e) emissive accents, crisp silhouettes --no shadows on background, no text, no overlapping
```

---

## 2. Tripo 3D 프롬프트 (Nano Banana 이미지와 함께 업로드)

Nano Banana에서 생성한 시트 이미지를 Tripo **Image-to-3D**에 업로드할 때, **이미지와 함께 입력창(프롬프트란)**에 넣어주면 파츠 분리 및 하드서페이스 각도 유지에 도움이 되는 보조 프롬프트입니다. *(Auto-Rig 옵션은 끄고 진행하세요.)*

- **[시트 A 이미지 + 함께 넣을 프롬프트]**
  ```text
  Modular sci-fi industrial arena floor tiles, blast walls, and open steel truss arches, separated distinct 3D objects, hard-surface dark gunmetal steel with cyan neon accents, clean sharp geometry, PBR textures.
  ```
- **[시트 B 이미지 + 함께 넣을 프롬프트]**
  ```text
  Modular sci-fi vertical arena catwalks, industrial stairs, cargo ramps, and lookout tower, separated distinct 3D objects, dark metallic steel with cyan LED and yellow hazard stripes, clean sharp geometry.
  ```
- **[시트 C 이미지 + 함께 넣을 프롬프트]**
  ```text
  Sci-fi tactical half-cover barricades, tall hexagonal pillars, bio-containment tanks, and cargo containers, separated distinct 3D objects, weathered dark gunmetal with cyan and red glowing accents.
  ```

---

## 3. Blender AI 에이전트 프롬프트 (Tripo 임포트 후 실행용)

Tripo Bridge로 Blender에 임포트한 뒤, 아래 프롬프트를 그대로 복사해 요청하세요.

### [시트 A 임포트 후]
```text
Tripo에서 바닥/벽/골조 환경 에셋 시트를 Blender로 import 했어.
각 항목을 하나하나 개별 오브젝트로 분리하고 중복이나 불필요한 파편은 지워줘.
우리 plan.md 규격에 맞게 실측 스케일(바닥 8x8m, 방폭벽 4x5m, 트러스 아치 8x6m 등)로 정규화하고, 피벗(Origin)은 모두 바닥면 정중앙(Z=0)에 맞춰줘.
완료되면 design/Environment/ 폴더에 SM_Crater_Floor_8x8.blend, SM_Blast_Wall_4m.blend, SM_Truss_Arch_OpenSky.blend 등으로 각각 저장하고 plan.md도 체크해줘.
```

### [시트 B 임포트 후]
```text
Tripo에서 캣워크/계단/램프/타워 수직 동선 시트를 Blender로 import 했어.
개별 오브젝트로 깔끔하게 분리하고 중복이나 파편은 정리해줘.
plan.md 규격(캣워크 6x2m, 플랫폼 4x4m, 계단 높이 4m, 타워 8m 등)에 맞춰 스케일을 정규화하고, 피벗(Origin)은 바닥면 정중앙(Z=0)으로 맞춰줘.
design/Environment/ 폴더에 SM_Catwalk_Straight_6m.blend, SM_Catwalk_Platform_4x4.blend, SM_Stairs_Industrial_4m.blend, SM_Ramp_Access_4m.blend, SM_Sniper_Tower_Octa.blend 등으로 저장하고 plan.md도 업데이트해줘.
```

### [시트 C 임포트 후]
```text
Tripo에서 전술 장애물 및 엄폐물 시트를 Blender로 import 했어.
각 장애물을 개별 메쉬로 분리하고, FPS 엄폐 규격(하프 엄폐물 높이 1.0m, 풀 엄폐물 높이 2.4m 등)에 맞춰 스케일을 정규화해줘.
피벗(Origin)은 바닥면 정중앙(Z=0)에 맞추고(매달린 컨테이너는 상단 고리 또는 정중앙), design/Environment/ 폴더에 SM_Cover_Low_Barricade.blend, SM_Cover_High_HexPillar.blend, SM_Cryo_Containment_Tank.blend, SM_Crane_Suspended_Cargo.blend 등으로 각각 저장한 뒤 plan.md도 체크해줘.
```

---

## 4. (선택) Tripo Text-to-3D 단품 직접 생성용 영문 프롬프트

시트가 아닌 단품으로 1개씩 직접 생성할 때 사용합니다.

- **공중 캣워크 (`SM_Catwalk_Straight_6m`)**
  ```text
  A modular elevated industrial sci-fi catwalk bridge, 6m long by 2m wide, see-through steel floor grating, heavy safety pipe railings on both sides at 1.1m height with cyan neon strip, dark gunmetal finish, game ready modular level asset.
  ```
- **산업용 연결 계단 (`SM_Stairs_Industrial_4m`)**
  ```text
  A heavy duty modular industrial steel staircase for vertical level design, 4m vertical rise, 2m tread width, diamond plate anti-slip steps, yellow hazard handrails, weathered dark metallic finish.
  ```
- **오픈스카이 트러스 아치 (`SM_Truss_Arch_OpenSky`)**
  ```text
  A massive architectural open steel truss frame arch for an open-sky arena, 8m wide by 6m tall, hollow tubular scaffolding lattice framework, industrial crane structure look, no roof sheeting, exposes the sky.
  ```
- **하프 엄폐 바리케이드 (`SM_Cover_Low_Barricade`)**
  ```text
  A tactical low barricade obstacle for combat cover, 1.8m wide, 0.6m deep, 1.0m tall, angled ballistic armor plates, scuffed dark gray composite metal with cyan LED status indicator, flat grounded bottom.
  ```
- **풀 엄폐 육각 기둥 (`SM_Cover_High_HexPillar`)**
  ```text
  A tall hexagonal industrial pillar obstacle for full player cover, 1.2m diameter, 2.4m tall, heavy armored plating, exposed thick hydraulic cables, warning hazard stripes, matte dark steel texture, game asset.
  ```
