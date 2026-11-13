# Tripo 3D 생성용 프롬프트 리스트 (`prompt.md`)

> **사용 방법 요약**
> 1. **개별 Image-to-3D (추천)**: [`design/References/Cropped/`](file:///home/yang/work/ai-sample/design/References/Cropped) 폴더에 있는 `01`~`16`번 개별 크롭 이미지를 Tripo에 1장씩 올리세요.
> 2. **개별 Text-to-3D / 이미지 생성**: 아래 **1~4번 섹션**의 영문 프롬프트 코드블록을 그대로 복사해 Tripo에 붙여넣으세요.
> 3. **5개 한 번에 시트 이미지로 생성할 때**: 맨 아래 **5번 섹션(5종 합본 시트 프롬프트)**을 사용해 이미지를 만든 뒤 알려주시면 5개로 잘라드립니다.
> 4. **손·발·다리·꼬리 움직임(리깅) 권장 옵션**:
>    - 캐릭터/몬스터는 프롬프트에 `A-pose, separated limbs, rigging-ready`가 포함되어 있습니다.
>    - Tripo에서 모델 생성 후 하단 **Rig (Auto-Rig)** 탭을 누르면 팔·다리·손·발·꼬리에 자동으로 뼈대(Armature)가 생성됩니다.

---

## 1. 무기 5종 (Weapons — `gun.png` 기준)

### 01. ARC-42 '발키리' 전자기 가속 돌격소총 (`Wep_ARC42_Valkyrie`)
- **크롭 이미지**: [`design/References/Cropped/01_Wep_ARC42_Valkyrie.png`](file:///home/yang/work/ai-sample/design/References/Cropped/01_Wep_ARC42_Valkyrie.png)
```text
Futuristic sci-fi electromagnetic assault rifle, matte dark titanium and carbon fiber receiver, long handguard with 6 glowing cyan-blue electromagnetic induction coils visible through side vents, top Picatinny rail with holographic smart optic sight and glowing blue ammo counter HUD screen, curved ribbed polymer magazine with glowing blue indicator strip, tactical skeletonized stock, multi-baffle muzzle brake, hard-surface game weapon asset, stylized PBR texture, clean isolated object, side profile proportion.
```

### 02. 베르겔미르-09 중(重)플라즈마 산탄총 (`Wep_Bergelmir09_Shotgun`)
- **크롭 이미지**: [`design/References/Cropped/02_Wep_Bergelmir09_Shotgun.png`](file:///home/yang/work/ai-sample/design/References/Cropped/02_Wep_Bergelmir09_Shotgun.png)
```text
Heavy sci-fi bullpup plasma shotgun, chunky white ceramic armor plating over dark grey metallic frame, quad 4-barrel magnetic ring muzzle nozzles stacked vertically, top integrated carry handle rail, dark grey ribbed pump-action forend grip, cylindrical glowing blue liquid helium coolant tank mounted horizontally inside the rear bullpup stock, thumbhole grip, hard-surface game weapon asset, high detail PBR, clean isolated object.
```

### 03. 크로노스-V 고주파 레일 DMR (`Wep_KronosV_RailDMR`)
- **크롭 이미지**: [`design/References/Cropped/03_Wep_KronosV_RailDMR.png`](file:///home/yang/work/ai-sample/design/References/Cropped/03_Wep_KronosV_RailDMR.png)
```text
Long-barrel futuristic sci-fi railgun DMR sniper rifle, sleek silver and dark gunmetal grey chassis, split dual-rail electromagnetic barrel with glowing cyan plasma channel along the core, large high-magnification smart sniper scope on top rail, folding front tactical bipod under handguard, thumbhole sniper stock housing two vertical metallic silver cylinder capacitor canisters at the rear, hard-surface game weapon asset, PBR texture, clean isolated object.
```

### 04. 이지스-300 분산형 스마트 SMG (`Wep_Aegis300_SmartSMG`)
- **크롭 이미지**: [`design/References/Cropped/04_Wep_Aegis300_SmartSMG.png`](file:///home/yang/work/ai-sample/design/References/Cropped/04_Wep_Aegis300_SmartSMG.png)
```text
Compact futuristic Vector-lock smart submachine gun SMG, dark charcoal stealth polymer body with angled recoil-mitigation receiver, horizontal translucent cylindrical helical magazine mounted along the top receiver showing internal spiral ammo discs, circular smart radar targeting lens under the short ported barrel, vertical tactical foregrip, extended pistol mag, lightweight folding skeleton stock, hard-surface sci-fi weapon asset, clean isolated object.
```

### 05. 헬리오스-X 극초단파 집속 빔 캐넌 (`Wep_HeliosX_BeamCannon`)
- **크롭 이미지**: [`design/References/Cropped/05_Wep_HeliosX_BeamCannon.png`](file:///home/yang/work/ai-sample/design/References/Cropped/05_Wep_HeliosX_BeamCannon.png)
```text
Heavy industrial sci-fi continuous arc-beam cannon minigun, rugged yellow hazard-painted industrial housing with weathered metal edges, 3-barrel rotary cluster at the front bound by yellow clamping rings, thick exposed red and black braided high-voltage power cables snaking along the side of the receiver, ribbed cylindrical drum reactor under the body, massive blocky silver and yellow rear fusion power cell pack with cooling vents, hard-surface heavy weapon asset, clean isolated object.
```

---

## 2. 플레이어 아바타 5종 (Player Avatars — `avartar.png` 기준, 리깅용 A-Pose)

### 06. 어썰트 아웃라이더 (`SK_Player_AssaultOutrider` — 메인 플레이어)
- **크롭 이미지**: [`design/References/Cropped/06_SK_Player_AssaultOutrider.png`](file:///home/yang/work/ai-sample/design/References/Cropped/06_SK_Player_AssaultOutrider.png)
```text
Full-body futuristic sci-fi assault soldier character in sleek white and vibrant orange exo-suit armor, tactical helmet with dual glowing cyan optical scan visor lenses, compact 6-tube micro-missile pod mounted on the shoulder, glowing orange shield generator nodes on shoulders and knees, articulated armored gauntlets and combat boots, standing symmetrical front view A-pose, separated arms and legs, rigging-ready, high-detail stylized sci-fi game character, 4K PBR material.
```

### 07. 뱅가드 브레이커 (`CH_Avatar_VanguardBreaker` — 중장갑 돌격병)
- **크롭 이미지**: [`design/References/Cropped/07_CH_Avatar_VanguardBreaker.png`](file:///home/yang/work/ai-sample/design/References/Cropped/07_CH_Avatar_VanguardBreaker.png)
```text
Full-body heavy shock-trooper sci-fi marine in bulky navy blue and yellow-gold power armor, heavy helmet with glowing yellow-orange T-visor, massive tiered shoulder pauldrons with glowing red-orange radiator heat vents on the sides, reinforced chest plate, hydraulic dorsal power exoskeleton frame, heavy armored knee pads and boots, standing symmetrical front view A-pose, separated arms and legs, rigging-ready, high-detail hard-surface game character, 4K PBR.
```

### 08. 고스트 정찰병 (`CH_Avatar_GhostRecon` — 은폐 저격병)
- **크롭 이미지**: [`design/References/Cropped/08_CH_Avatar_GhostRecon.png`](file:///home/yang/work/ai-sample/design/References/Cropped/08_CH_Avatar_GhostRecon.png)
```text
Full-body futuristic sci-fi stealth sniper assassin in form-fitting dark slate grey and mint-teal tactical armor, stealth helmet with asymmetric glowing cyan spectrum scope visor lens, dark tactical scarf around neck, translucent glowing cyan holographic optical camouflage cape draped behind shoulders, agile armored greaves, standing symmetrical front view A-pose, separated arms and legs, rigging-ready, stylized sci-fi game character, 4K PBR.
```

### 09. 스트라이크 기어 (`CH_Avatar_StrikeGear` — 고속 기동병)
- **크롭 이미지**: [`design/References/Cropped/09_CH_Avatar_StrikeGear.png`](file:///home/yang/work/ai-sample/design/References/Cropped/09_CH_Avatar_StrikeGear.png)
```text
Full-body agile sci-fi skirmisher soldier in aerodynamic crimson red and metallic silver flight combat armor, sleek full-face silver reflective dome helmet with red crest, twin back-mounted high-speed jetpack thrusters with swept aero winglets and glowing blue afterburner exhaust, tactical ammo belt at waist, streamlined red and silver leg armor, standing symmetrical front view A-pose, separated arms and legs, rigging-ready, high-detail sci-fi character, 4K PBR.
```

### 10. 센티넬 디펜더 (`CH_Avatar_SentinelDefender` — 중화기 지원병)
- **크롭 이미지**: [`design/References/Cropped/10_CH_Avatar_SentinelDefender.png`](file:///home/yang/work/ai-sample/design/References/Cropped/10_CH_Avatar_SentinelDefender.png)
```text
Full-body juggernaut heavy support sci-fi soldier in massive olive green and bronze-gold tank armor, reinforced helmet with glowing yellow-gold faceplate and visor, bright glowing orange circular fusion reactor core embedded in the center of the chest plate, dorsal fusion generator backpack with overhead roll-bars, heavy hydraulic recoil-absorbing forearm gauntlets, wide boots with deployable ground anchors, standing symmetrical front view A-pose, separated arms and legs, rigging-ready, 4K PBR.
```

---

## 3. 몬스터 5종 & 결전 보스 1종 (Monsters & Boss — `monster.png`, `boss.png` 기준)

### 11. 스토커 (`CH_Monster_Stalker` — 4족 기계 표범)
- **크롭 이미지**: [`design/References/Cropped/11_CH_Monster_Stalker.png`](file:///home/yang/work/ai-sample/design/References/Cropped/11_CH_Monster_Stalker.png)
```text
Futuristic sci-fi biomechanical cyber-panther alien monster standing on four separated legs, sleek silver-blue metallic armor plates over dark synthetic muscle, predatory feline head with glowing cyan optical visor and sharp fangs, glowing cyan circular rotary power rings on shoulders and hips, cluster of sharp glowing cyan crystal energy spikes erupting from its upper back, digitigrade clawed paws, long segmented metallic whip tail with blade tip, rigging-ready quadruped monster asset, 4K PBR.
```

### 12. 제노 트루퍼 (`CH_Monster_XenoTrooper` — 외계 보병)
- **크롭 이미지**: [`design/References/Cropped/12_CH_Monster_XenoTrooper.png`](file:///home/yang/work/ai-sample/design/References/Cropped/12_CH_Monster_XenoTrooper.png)
```text
Bipedal alien warrior infantry monster in biomechanical bronze and dark brown heavy chitinous composite armor, curved alien helmet with glowing orange V-slit visor, bright glowing orange spherical power core in the center of the chest with glowing orange energy veins coursing across the torso, arms, and thighs, standing symmetrical A-pose with separated arms and legs, rigging-ready sci-fi enemy character, 4K PBR.
```

### 13. 가디언 비스트 (`CH_Monster_GuardianBeast` — 중장갑 결정 괴수)
- **크롭 이미지**: [`design/References/Cropped/13_CH_Monster_GuardianBeast.png`](file:///home/yang/work/ai-sample/design/References/Cropped/13_CH_Monster_GuardianBeast.png)
```text
Massive quadrupedal sci-fi armored rhino-ankylosaur kaiju beast standing on four separated thick armored legs, heavy overlapping yellow and dark gunmetal shielding armor plates across its bulky body, large glowing cyan crystalline horn on its snout, huge jagged clusters of glowing cyan energy crystal shards growing along its back spine, heavy claws, segmented armored tail ending in a spiked crusher club, rigging-ready quadruped monster asset, 4K PBR.
```

### 14. 스포어 플라이어 (`CH_Monster_SporeFlyer` — 비행 정찰 괴수)
- **크롭 이미지**: [`design/References/Cropped/14_CH_Monster_SporeFlyer.png`](file:///home/yang/work/ai-sample/design/References/Cropped/14_CH_Monster_SporeFlyer.png)
```text
Futuristic biomechanical alien hornet drone creature in mid-flight, streamlined yellow and white armored carapace with a curved glowing cyan cockpit canopy visor at the front, four large translucent glowing cyan energy propulsion wings spreading out clearly in an X-pattern, two underslung cylindrical yellow and grey rotary spore-launcher pods with glowing yellow nozzles hanging beneath the body, sci-fi flying monster asset, 4K PBR.
```

### 15. 티탄 브레이커 (`CH_Monster_TitanBreaker` — 중장갑 거인 메카)
- **크롭 이미지**: [`design/References/Cropped/15_CH_Monster_TitanBreaker.png`](file:///home/yang/work/ai-sample/design/References/Cropped/15_CH_Monster_TitanBreaker.png)
```text
Hulking sci-fi siege mech-golem titan monster, massive silver-grey heavy armor plating, menacing recessed head with glowing orange visor slits, exposed glowing red-orange hexagonal energy core weakpoint in the center of the chest, two giant shoulder-mounted rectangular rocket cannon pods each with 6 glowing orange barrel muzzles, enormous hydraulic crusher gauntlets with glowing orange side heat vents, thick armored legs, standing symmetrical A-pose, separated arms and legs, rigging-ready, 4K PBR.
```

### 16. 결전 보스: 아크 드레드 레이즈 (`CH_Boss_ArchDreadRaze` — 사이버 드래곤 메카)
- **크롭 이미지**: [`design/References/Cropped/16_CH_Boss_ArchDreadRaze.png`](file:///home/yang/work/ai-sample/design/References/Cropped/16_CH_Boss_ArchDreadRaze.png)
```text
Colossal futuristic biomechanical cyber-dragon mecha boss monster, white titanium and dark gunmetal interlocking armor plates with glowing orange energy seams, fierce mechanical dragon head with glowing cyan optical visor and fanged jaws, large glowing orange circular plasma reactor core in the center of its chest, twin shoulder-mounted dual-barrel heavy particle cannons, giant robotic wing frames spread wide with translucent glowing cyan energy wing membranes, dorsal cyan crystal spikes on lower back, long segmented dragon tail with glowing red-hot overheated vent plates and sharp metallic tail blade spur, clearly separated arms, legs, wings, and tail, rigging-ready boss asset, 4K PBR.
```

---

## 4. 맵 환경 에셋: 바닥 · 벽체 · 천장 장식 · 기둥 · 문 · 엄폐물 (Map Environment & Ceiling Props)

### [바닥 (Floors)]

#### 17. 메인 금속 그리드 복도 바닥 (`SM_Corridor_Floor`)
```text
Modular sci-fi underground excavation facility corridor floor tile 12x5m, dark metallic industrial grate center showing sub-floor pipes underneath, raised diamond-plate steel walkways, glowing cyan LED guide strips along the edges, industrial yellow-black hazard stripes on borders, flat modular game environment floor asset, 4K PBR.
```

#### 18. 보스룸/교차로 중앙 플랫폼 바닥 (`SM_Corridor_Floor_Hub`)
```text
Modular sci-fi octagonal command hub floor platform tile, heavy reinforced dark titanium floor plates with recessed glowing cyan hexagonal circuit channels, central circular cargo lift ring with caution markings, weathered industrial metal surface, modular game floor asset, 4K PBR.
```

#### 19. 배수로/케이블 트렌치 바닥 (`SM_Corridor_Floor_Trench`)
```text
Modular sci-fi industrial floor tile with recessed central cable trench covered by removable perforated steel grating, glowing blue fiber-optic conduits and coolant pipes visible inside the floor channel, heavy bolted metal frame, game environment floor asset, 4K PBR.
```

---

### [벽체 & 방폭문 (Walls & Bulkhead Doors)]

#### 20. 중장갑 복도 기본 벽체 (`SM_Corridor_Wall`)
```text
Modular sci-fi industrial bulkhead wall panel 5m wide by 4.2m high, angled dark gunmetal armor plates, recessed maintenance hatches with warning stencils, horizontal reinforcement ribs, glowing cyan status light strip at mid-height, heavy bolted base trim, dark sci-fi horror corridor wall asset, 4K PBR.
```

#### 21. 배전반/제어 패널 벽체 (`SM_Corridor_Wall_Control`)
```text
Modular sci-fi facility wall panel with embedded high-voltage power distribution box, diagnostic holographic cyan screen, heavy lever switches, warning labels, and vertical conduit pipes, dark industrial metal wall module, 4K PBR.
```

#### 22. 대형 방폭 격벽문 (`SM_Corridor_BulkheadDoor`)
```text
Massive futuristic sci-fi armored blast door bulkhead frame, twin interlocking heavy steel sliding door leaves with yellow-black hazard chevrons, central hydraulic locking wheel mechanism, top red/cyan security status indicator lamp, underground laboratory gate asset, 4K PBR.
```

---

### [천장 & 천장 장식/조명 (Ceilings & Ceiling Decorations)]

#### 23. 중장갑 천장 마감 패널 & 환기구 (`SM_Corridor_CeilingPanel`)
```text
Modular sci-fi industrial corridor ceiling panel module, recessed dark steel coffered ceiling structure with large slatted air ventilation exhaust louvers, bolted structural crossbeams, and integrated cable conduits, game environment ceiling asset, 4K PBR.
```

#### 24. 천장 현수 케이블 트레이 & 파이프 랙 장식 (`SM_Corridor_CeilingCableRack`)
```text
Sci-fi ceiling-suspended industrial utility rack decoration, hanging steel trapeze struts supporting bundled high-voltage power cables, glowing cyan coolant tubes, and weathered ventilation ducting, modular overhead corridor detail prop, 4K PBR.
```

#### 25. 천장 시안 네온 발광 스트립 (`SM_Corridor_NeonStrip`)
```text
Sci-fi ceiling-mounted industrial neon light fixture bar, dark anodized aluminum housing with protective steel wire cage brackets and bright glowing cyan-blue plasma tube, modular overhead lighting prop, 4K PBR.
```

#### 26. 천장 적색 비상 경보등 & 센서 포드 (`SM_Corridor_CeilingAlarm`)
```text
Futuristic sci-fi ceiling-mounted emergency alarm beacon and security sensor pod, heavy dark metal bracket holding a protective metal cage over a bright glowing red warning siren lamp alongside a small armored optical camera dome, game environment ceiling prop, 4K PBR.
```

#### 27. 천장 대형 크레인 레일 & 호이스트 장식 (`SM_Corridor_CeilingGantry`)
```text
Industrial sci-fi overhead ceiling gantry crane rail beam module, yellow-black painted steel I-beam track with motorized mechanical pulley trolley and hanging heavy chain hook, underground excavation facility ceiling decoration prop, 4K PBR.
```

---

### [기둥 · 배관 · 엄폐물 (Pillars, Pipes & Tactical Covers)]

#### 28. 아치형 보강 기둥 & 상단 가로보 (`SM_Corridor_ArchPillar`)
```text
Futuristic sci-fi structural arch pillar support column with angled overhead ceiling buttress beam, heavy H-beam dark steel profile, hydraulic shock dampers, yellow-black hazard markings at base, glowing cyan vertical status light strip, modular underground facility prop, 4K PBR.
```

#### 29. 벽면 고압 배관 파이프 모듈 (`SM_Corridor_WallPipe`)
```text
Sci-fi industrial wall-mounted twin coolant pipe module, brushed steel pipes with bolted flange joints, heavy clamping brackets, analog pressure gauge, and red rotary shutoff valve wheel, modular game prop, 4K PBR.
```

#### 30. 하프 전술 엄폐물 (`SM_Cover_Half_01`)
```text
Futuristic sci-fi deployable tactical half-cover barricade chest-high, sloped heavy dark grey ballistic armor front plate, yellow-black hazard stripe base, rear glowing cyan portable shield battery pack, FPS tactical cover prop, 4K PBR.
```

#### 31. 풀 방탄 기둥 엄폐물 (`SM_Cover_Full_01`)
```text
Tall futuristic sci-fi hexagonal armored blast shield full-body cover pillar 2.2m high, heavy steel reinforcement ribs, upper armored slit viewport with glowing cyan ballistic glass, heavy base stabilizers, FPS tactical cover prop, 4K PBR.
```

---

## 5. (참고) 5개 한 번에 컨셉 시트 이미지를 생성할 때 쓰는 프롬프트
> 이미지 생성기에서 한 장에 5개짜리 컨셉 시트를 새로 뽑고 싶을 때 사용하세요. 생성된 이미지를 주시면 `crop_concept_sheets.py`로 5개로 잘라드립니다.

### A. 무기 5종 합본 컨셉 시트 프롬프트
```text
Sci-fi FPS weapon concept art sheet displaying 5 distinct futuristic guns stacked vertically on a clean dark slate blueprint background, no overlapping: (1) dark titanium assault rifle with 6 glowing blue handguard coils and holographic ammo counter sight, (2) white ceramic bullpup heavy plasma shotgun with quad barrel nozzles and rear blue coolant tank, (3) long silver-grey dual-rail sniper DMR rifle with scope and rear twin silver capacitor cylinders, (4) compact black stealth smart SMG with top horizontal translucent cylindrical magazine, (5) yellow industrial heavy rotary 3-barrel beam cannon with red/black power cables and rear battery pack. Clean side-view orthographic game asset sheet, sharp edges, high detail.
```

### B. 플레이어 아바타 5종 합본 컨셉 시트 프롬프트
```text
Sci-fi FPS character concept art sheet showing 5 full-body futuristic armored soldiers standing side-by-side in front-facing A-pose on a clean dark background, clearly separated with no overlapping: (1) white and orange assault soldier with cyan scan visor and shoulder missile pod, (2) bulky navy blue and yellow heavy shock trooper marine, (3) dark grey and mint-teal stealth sniper with glowing cyan optical cloak, (4) sleek crimson red and silver jetpack skirmisher soldier, (5) olive green and bronze heavy juggernaut defender with glowing orange chest reactor core. Symmetrical A-pose, separated limbs, high detail game character sheet.
```

### C. 몬스터 5종 합본 컨셉 시트 프롬프트
```text
Sci-fi FPS enemy monster concept art sheet showing 5 distinct biomechanical alien creatures arranged in a clean grid on a dark background with no overlapping: (1) silver-blue quadrupedal cyber-panther with glowing cyan back crystal spikes, (2) bipedal bronze-armored alien trooper with glowing orange chest core, (3) bulky yellow and gunmetal quadrupedal armored kaiju beast with cyan crystal shards on its back, (4) flying yellow-white biomechanical hornet drone with four translucent cyan energy wings, (5) massive silver-grey siege mech titan with dual shoulder 6-tube orange rocket pods and glowing orange chest core. Clean game concept sheet, high detail.
```

### D. 맵 환경 모듈 5종 합본 시트 프롬프트 (바닥 · 벽체 · 천장 장식 · 아치 기둥 · 방폭문)
```text
Sci-fi underground laboratory modular environment asset sheet displaying 5 isolated architectural props on a clean dark background with no overlapping: (1) metallic industrial grate corridor floor tile with glowing cyan LED strips and yellow-black hazard borders, (2) heavy dark gunmetal bulkhead wall panel with maintenance hatch and glowing cyan status bar, (3) overhead ceiling utility decoration rack with suspended high-voltage cables, ventilation duct, and glowing cyan neon light bar, (4) structural H-beam arch support pillar with hydraulic dampers, (5) twin-sliding armored blast bulkhead door with central locking wheel and red warning beacon. Clean 3D game asset sheet, 4K PBR style.
```
