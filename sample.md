<!DOCTYPE html>
<html lang="ko">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>PROJECT: OMEGA PROTOCOL - FPS Concept Mockup</title>
  <!-- Tailwind CSS -->
  <script src="https://cdn.tailwindcss.com"></script>
  <!-- Three.js & Tone.js -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/three.js/r128/three.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/tone/14.8.49/Tone.js"></script>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Orbitron:wght@400;600;800;900&family=Rajdhani:wght@500;600;700&display=swap" rel="stylesheet">

  <style>
    * {
      user-select: none;
      -webkit-user-select: none;
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
    body, html {
      width: 100%;
      height: 100%;
      overflow: hidden;
      background-color: #030508;
      font-family: 'Rajdhani', sans-serif;
      color: #e2e8f0;
    }
    .font-scifi {
      font-family: 'Orbitron', monospace;
    }

    /* Post Processing & Overlay Styles */
    .vignette-effect {
      background: radial-gradient(circle at center, transparent 40%, rgba(2, 6, 14, 0.85) 90%, #000000 100%);
    }
    .scanline-effect {
      background: linear-gradient(rgba(18, 16, 16, 0) 50%, rgba(0, 0, 0, 0.45) 50%);
      background-size: 100% 4px;
    }
    .crt-curvature {
      box-shadow: inset 0 0 100px rgba(0, 0, 0, 0.95);
    }
    .night-vision-tint {
      mix-blend-mode: color;
      background-color: rgba(18, 255, 110, 0.45);
    }
    .thermal-vision-tint {
      mix-blend-mode: hard-light;
      background: radial-gradient(circle at 50% 50%, rgba(255, 60, 0, 0.5), rgba(40, 10, 200, 0.7));
    }

    /* Futuristic HUD Glass & Glows */
    .hud-glow-cyan {
      text-shadow: 0 0 8px rgba(34, 211, 238, 0.8), 0 0 20px rgba(6, 182, 212, 0.4);
    }
    .hud-glow-red {
      text-shadow: 0 0 10px rgba(239, 68, 68, 0.9), 0 0 25px rgba(220, 38, 38, 0.6);
    }
    .hud-border-cyan {
      border-color: rgba(34, 211, 238, 0.35);
      box-shadow: 0 0 15px rgba(6, 182, 212, 0.15), inset 0 0 10px rgba(6, 182, 212, 0.08);
    }
    .hud-border-red {
      border-color: rgba(239, 68, 68, 0.5);
      box-shadow: 0 0 15px rgba(239, 68, 68, 0.25), inset 0 0 10px rgba(220, 38, 38, 0.15);
    }

    /* Radar Ping Animation */
    @keyframes radarSweep {
      0% { transform: rotate(0deg); }
      100% { transform: rotate(360deg); }
    }
    .radar-sweep {
      animation: radarSweep 3.5s linear infinite;
      transform-origin: center center;
    }

    /* Alarm pulse */
    @keyframes pulseAlert {
      0%, 100% { opacity: 0.1; }
      50% { opacity: 0.55; }
    }
    .alarm-flash {
      animation: pulseAlert 1.6s ease-in-out infinite;
    }

    /* Reticle Pulse */
    @keyframes reticleExpand {
      0% { transform: scale(1); }
      50% { transform: scale(1.18); }
      100% { transform: scale(1); }
    }
    .reticle-fire {
      animation: reticleExpand 0.12s ease-out;
    }

    /* Glass Panels */
    .scifi-panel {
      background: linear-gradient(135deg, rgba(8, 18, 30, 0.72) 0%, rgba(3, 7, 18, 0.88) 100%);
      backdrop-filter: blur(8px);
      -webkit-backdrop-filter: blur(8px);
    }

    /* Custom scrollbars */
    ::-webkit-scrollbar {
      width: 4px;
    }
    ::-webkit-scrollbar-thumb {
      background: rgba(34, 211, 238, 0.4);
      border-radius: 4px;
    }
  </style>
</head>
<body class="relative w-screen h-screen overflow-hidden select-none cursor-crosshair">

  <!-- 3D WebGL Canvas Layer -->
  <div id="canvas-container" class="absolute inset-0 z-0"></div>

  <!-- Audio Initializer Barrier for Browser Autoplay Policy -->
  <div id="audio-init-modal" class="absolute inset-0 z-50 flex items-center justify-center bg-black/85 backdrop-blur-md">
    <div class="max-w-md p-6 text-center scifi-panel border border-cyan-500/40 rounded-xl shadow-2xl">
      <div class="inline-flex items-center justify-center w-16 h-16 rounded-full bg-cyan-500/10 border border-cyan-400 mb-4">
        <i class="fa-solid fa-crosshairs text-2xl text-cyan-400 animate-pulse"></i>
      </div>
      <h2 class="text-xl font-scifi font-bold tracking-widest text-white mb-2">PROJECT: TARTARUS</h2>
      <p class="text-xs text-slate-400 mb-6 uppercase tracking-wider">Tactical Bio-Combat Simulation Interface</p>
      <button id="btn-enter" class="w-full py-3 px-6 bg-gradient-to-r from-cyan-600 to-blue-700 hover:from-cyan-500 hover:to-blue-600 text-white font-scifi font-semibold text-sm tracking-widest rounded uppercase transition duration-200 shadow-lg shadow-cyan-600/30">
        시스템 시뮬레이션 진입 [CLICK TO ENGAGE]
      </button>
      <p class="text-[11px] text-slate-500 mt-4"><i class="fa-solid fa-volume-high mr-1"></i> 사운드 이펙트 및 마우스 조준이 활성화됩니다.</p>
    </div>
  </div>

  <!-- Post-processing Filters Layer (Toggled dynamically) -->
  <div id="vignette-layer" class="pointer-events-none absolute inset-0 z-10 vignette-effect"></div>
  <div id="scanline-layer" class="pointer-events-none absolute inset-0 z-10 scanline-effect opacity-40"></div>
  <div id="vision-mode-layer" class="pointer-events-none absolute inset-0 z-10 opacity-0 transition-opacity duration-300"></div>
  <div id="alarm-border" class="pointer-events-none absolute inset-0 z-10 border-[6px] border-red-600/0 transition-all duration-300"></div>

  <!-- HUD Interface Layer -->
  <div class="relative z-20 w-full h-full flex flex-col justify-between p-4 md:p-6 pointer-events-none">

    <!-- TOP BAR: Station Telemetry, Compass & Threat Status -->
    <header class="flex justify-between items-start w-full">
      
      <!-- Top Left: Operational Status -->
      <div class="scifi-panel p-3.5 rounded-lg border hud-border-cyan flex flex-col gap-1 w-64">
        <div class="flex items-center justify-between text-xs font-scifi tracking-wider">
          <span class="text-cyan-400 flex items-center gap-1.5 font-bold">
            <span class="w-2 h-2 rounded-full bg-cyan-400 animate-ping"></span> SEC-04 EXCAVATION
          </span>
          <span class="text-slate-400 font-mono">REC [00:41:19]</span>
        </div>
        <div class="flex items-center justify-between text-[11px] text-slate-300 border-t border-slate-700/60 pt-1 mt-1 font-mono">
          <span>O2: 97.4%</span>
          <span>TEMP: -4.2°C</span>
          <span class="text-amber-400">RAD: 14 mSv/h</span>
        </div>
        <div class="text-[10px] text-slate-400 flex items-center justify-between">
          <span>ATMOSPHERE: CONTAMINATED</span>
          <span class="text-red-400 font-bold animate-pulse">BIO-HAZARD L-4</span>
        </div>
      </div>

      <!-- Top Center: Tactical Digital Compass Heading -->
      <div class="flex flex-col items-center">
        <div class="scifi-panel px-6 py-2 rounded-md border hud-border-cyan flex items-center gap-4">
          <span class="text-xs text-slate-500 font-mono">NW</span>
          <span class="text-xs text-slate-400 font-mono">315</span>
          <span class="text-sm font-scifi font-bold text-cyan-400 hud-glow-cyan tracking-widest border-x border-cyan-400/40 px-3">
            N <span id="compass-deg">004°</span>
          </span>
          <span class="text-xs text-slate-400 font-mono">045</span>
          <span class="text-xs text-slate-500 font-mono">NE</span>
        </div>
        <div class="text-[10px] font-mono tracking-widest text-cyan-500/80 mt-1 uppercase flex items-center gap-1.5">
          <i class="fa-solid fa-location-crosshairs text-[9px]"></i> TARGET: SPECIMEN-09 EXTERMINATION
        </div>
      </div>

      <!-- Top Right: Threat Proximity Alert & Threat Gauge -->
      <div class="scifi-panel p-3.5 rounded-lg border hud-border-red flex flex-col gap-1.5 w-64 text-right">
        <div class="flex items-center justify-between">
          <span class="text-[11px] font-mono text-red-400 uppercase tracking-widest flex items-center gap-1">
            <i class="fa-solid fa-triangle-exclamation animate-bounce"></i> PROXIMITY ALERT
          </span>
          <span id="threat-indicator" class="text-xs font-scifi font-black text-red-500 hud-glow-red tracking-wider">CRITICAL</span>
        </div>
        <!-- Segmented Threat Bar -->
        <div class="w-full bg-slate-900/80 h-2.5 rounded-sm overflow-hidden flex gap-0.5 p-0.5 border border-red-500/30">
          <div class="bg-red-500/30 h-full flex-1"></div>
          <div class="bg-red-500/50 h-full flex-1"></div>
          <div class="bg-red-500/80 h-full flex-1"></div>
          <div class="bg-red-500 h-full flex-1 animate-pulse"></div>
          <div class="bg-red-500 h-full flex-1 animate-ping"></div>
        </div>
        <div class="flex justify-between items-center text-[10px] font-mono text-slate-400">
          <span>HOSTILE TARGET</span>
          <span class="text-red-400 font-bold" id="monster-distance">DIST: 14.2 M</span>
        </div>
      </div>
    </header>

    <!-- CENTER RETICLE & TARGET LOCK -->
    <div class="absolute inset-0 flex items-center justify-center pointer-events-none">
      <div id="crosshair-ui" class="relative w-44 h-44 flex items-center justify-center transition-transform duration-75">
        <!-- Reticle Ring -->
        <div class="absolute inset-0 rounded-full border border-cyan-400/20"></div>
        <div class="absolute inset-3 rounded-full border border-dashed border-cyan-400/30 animate-spin" style="animation-duration: 25s;"></div>
        
        <!-- Reticle Brackets -->
        <div class="absolute -top-1 w-6 h-1 bg-cyan-400 shadow-[0_0_8px_#22d3ee]"></div>
        <div class="absolute -bottom-1 w-6 h-1 bg-cyan-400 shadow-[0_0_8px_#22d3ee]"></div>
        <div class="absolute -left-1 w-1 h-6 bg-cyan-400 shadow-[0_0_8px_#22d3ee]"></div>
        <div class="absolute -right-1 w-1 h-6 bg-cyan-400 shadow-[0_0_8px_#22d3ee]"></div>

        <!-- Center Aim Dot -->
        <div class="w-1.5 h-1.5 rounded-full bg-cyan-400 shadow-[0_0_6px_#22d3ee]"></div>

        <!-- Hostile Target Box Bracket -->
        <div class="absolute -top-12 -left-12 border-t-2 border-l-2 border-red-500 w-5 h-5 opacity-80"></div>
        <div class="absolute -top-12 -right-12 border-t-2 border-r-2 border-red-500 w-5 h-5 opacity-80"></div>
        <div class="absolute -bottom-12 -left-12 border-b-2 border-l-2 border-red-500 w-5 h-5 opacity-80"></div>
        <div class="absolute -bottom-12 -right-12 border-b-2 border-r-2 border-red-500 w-5 h-5 opacity-80"></div>
        
        <span class="absolute -bottom-16 text-[9px] font-mono text-red-400 uppercase tracking-widest bg-red-950/70 px-2 py-0.5 rounded border border-red-500/40">
          LOCKED: BIOTITAN // HOSTILE
        </span>
      </div>
    </div>

    <!-- BOTTOM BAR: Vitals / Weapon Telemetry / Radar / Tactical Controls -->
    <footer class="flex flex-col md:flex-row justify-between items-end gap-4 w-full">
      
      <!-- Bottom Left: Vital Health, Nano-Shield, Rig Status -->
      <div class="scifi-panel p-4 rounded-xl border hud-border-cyan w-full md:w-80 space-y-3">
        <!-- Shield -->
        <div>
          <div class="flex justify-between items-center text-xs font-scifi mb-1">
            <span class="text-cyan-400 flex items-center gap-1.5"><i class="fa-solid fa-shield-halved"></i> SHIELD MATRIX</span>
            <span id="shield-val" class="font-bold text-cyan-300">85%</span>
          </div>
          <div class="w-full bg-slate-900 h-2.5 rounded overflow-hidden p-0.5 border border-cyan-500/30">
            <div id="shield-bar" class="h-full bg-gradient-to-r from-cyan-600 to-cyan-300 rounded-sm transition-all duration-300" style="width: 85%;"></div>
          </div>
        </div>

        <!-- Vital Health -->
        <div>
          <div class="flex justify-between items-center text-xs font-scifi mb-1">
            <span class="text-emerald-400 flex items-center gap-1.5"><i class="fa-solid fa-heart-pulse"></i> VITALITY</span>
            <span id="health-val" class="font-bold text-emerald-300">100%</span>
          </div>
          <div class="w-full bg-slate-900 h-2.5 rounded overflow-hidden p-0.5 border border-emerald-500/30">
            <div id="health-bar" class="h-full bg-gradient-to-r from-emerald-600 to-emerald-400 rounded-sm transition-all duration-300" style="width: 100%;"></div>
          </div>
        </div>

        <!-- Suit Power & Boost -->
        <div class="flex items-center justify-between text-[11px] font-mono text-slate-400 pt-1 border-t border-slate-700/50">
          <span class="flex items-center gap-1"><i class="fa-solid fa-bolt text-amber-400"></i> BATTERY: 98%</span>
          <span class="flex items-center gap-1"><i class="fa-solid fa-person-running text-blue-400"></i> STAMINA: OPTIMAL</span>
        </div>
      </div>

      <!-- Center Bottom: Interactive HUD Tactical Controls & Weapon Triggers -->
      <div class="pointer-events-auto flex flex-col items-center gap-2">
        <!-- Action Buttons (Clickable) -->
        <div class="flex items-center gap-2 scifi-panel p-2 rounded-lg border border-slate-700/80 shadow-2xl">
          <button id="btn-fire" class="px-4 py-2 bg-red-600 hover:bg-red-500 active:scale-95 text-white font-scifi font-bold text-xs rounded transition flex items-center gap-1.5 shadow-[0_0_12px_rgba(239,68,68,0.5)]">
            <i class="fa-solid fa-crosshairs"></i> 사격 [FIRE]
          </button>
          <button id="btn-reload" class="px-3 py-2 bg-slate-800 hover:bg-slate-700 active:scale-95 text-slate-200 font-scifi text-xs rounded border border-slate-600 transition flex items-center gap-1.5">
            <i class="fa-solid fa-rotate-right"></i> 재장전
          </button>
          <button id="btn-nvg" class="px-3 py-2 bg-slate-800 hover:bg-slate-700 active:scale-95 text-emerald-400 font-scifi text-xs rounded border border-emerald-500/40 transition flex items-center gap-1.5">
            <i class="fa-solid fa-eye"></i> 야간투시
          </button>
          <button id="btn-thermal" class="px-3 py-2 bg-slate-800 hover:bg-slate-700 active:scale-95 text-orange-400 font-scifi text-xs rounded border border-orange-500/40 transition flex items-center gap-1.5">
            <i class="fa-solid fa-fire"></i> 열화상
          </button>
          <button id="btn-light" class="px-3 py-2 bg-slate-800 hover:bg-slate-700 active:scale-95 text-cyan-400 font-scifi text-xs rounded border border-cyan-500/40 transition flex items-center gap-1.5">
            <i class="fa-solid fa-lightbulb"></i> 택티컬 라이트
          </button>
        </div>

        <!-- Quick Help Legend -->
        <div class="text-[10px] font-mono text-slate-400 uppercase tracking-wider flex gap-4">
          <span><kbd class="px-1.5 py-0.5 bg-slate-800 rounded border border-slate-600 text-slate-300">L-CLICK</kbd> 무기 격발</span>
          <span><kbd class="px-1.5 py-0.5 bg-slate-800 rounded border border-slate-600 text-slate-300">R</kbd> 재장전</span>
          <span><kbd class="px-1.5 py-0.5 bg-slate-800 rounded border border-slate-600 text-slate-300">N / T</kbd> 투시 모드 변경</span>
          <span><kbd class="px-1.5 py-0.5 bg-slate-800 rounded border border-slate-600 text-slate-300">DRAG</kbd> 시점 탐색</span>
        </div>
      </div>

      <!-- Bottom Right: Dynamic Minimap Radar & Weapon Munitions Gauge -->
      <div class="flex items-center gap-3">
        
        <!-- Tactical Minimap Radar -->
        <div class="scifi-panel p-2.5 rounded-xl border hud-border-cyan flex flex-col items-center relative">
          <div class="relative w-28 h-28 rounded-full border border-cyan-500/40 bg-slate-950/70 overflow-hidden flex items-center justify-center">
            <!-- Concentric Grid -->
            <div class="absolute inset-2 rounded-full border border-dashed border-cyan-500/20"></div>
            <div class="absolute inset-6 rounded-full border border-cyan-500/20"></div>
            <div class="absolute w-full h-[1px] bg-cyan-500/30"></div>
            <div class="absolute h-full w-[1px] bg-cyan-500/30"></div>

            <!-- Rotating Radar Sweep Line -->
            <div class="absolute inset-0 radar-sweep">
              <div class="w-1/2 h-1/2 bg-gradient-to-r from-transparent to-cyan-400/40 origin-bottom-right" style="clip-path: polygon(100% 100%, 0 100%, 100% 0);"></div>
            </div>

            <!-- Player Point (Center) -->
            <div class="relative z-10 w-2.5 h-2.5 bg-cyan-400 rounded-full border border-white shadow-[0_0_6px_#22d3ee]"></div>

            <!-- Threat Radar Blip (Monster) -->
            <div id="radar-blip-monster" class="absolute top-6 left-12 w-2.5 h-2.5 bg-red-500 rounded-full animate-ping"></div>
            <div class="absolute top-6 left-12 w-2 h-2 bg-red-600 rounded-full shadow-[0_0_8px_#ef4444]"></div>
          </div>
          <span class="text-[9px] font-mono text-cyan-400 tracking-wider mt-1.5 font-semibold">RADAR 30M RANGE</span>
        </div>

        <!-- Weapon Ammo & Firemode Matrix -->
        <div class="scifi-panel p-4 rounded-xl border hud-border-cyan w-48 text-right space-y-1">
          <div class="text-[10px] font-mono text-cyan-400 tracking-wider flex justify-between items-center">
            <span class="px-1.5 py-0.5 rounded bg-cyan-950/80 border border-cyan-500/40 text-[9px]">PULSE CARBINE</span>
            <span class="text-emerald-400">FULL-AUTO</span>
          </div>

          <!-- Ammo Count Display -->
          <div class="flex items-baseline justify-end gap-1.5 my-1">
            <span id="current-ammo" class="text-4xl font-scifi font-black text-cyan-300 hud-glow-cyan leading-none">36</span>
            <span class="text-sm font-mono text-slate-400">/ <span id="max-ammo">45</span></span>
          </div>

          <!-- Ammo Bar Segments -->
          <div class="w-full bg-slate-900 h-2 rounded overflow-hidden p-0.5 border border-cyan-500/30 flex gap-0.5">
            <div id="ammo-bar" class="h-full bg-cyan-400 transition-all duration-100" style="width: 80%;"></div>
          </div>

          <div class="flex justify-between items-center text-[10px] font-mono text-slate-400 pt-1 border-t border-slate-700/60">
            <span>MAG: 4/4</span>
            <span class="text-cyan-400 font-bold">TYPE: KINETIC-PL</span>
          </div>
        </div>

      </div>

    </footer>

  </div>

  <!-- Audio and Visual Logic / WebGL Engine Script -->
  <script>
    // --- Global Game Audio Synthesizer (Tone.js) ---
    let audioReady = false;
    let weaponSynth, monsterGrowlSynth, alarmSynth, clickSynth;

    function initAudio() {
      if (audioReady) return;
      try {
        Tone.start();

        // Gunshot synthesizer (Snappy noise + low frequency kick)
        weaponSynth = new Tone.PolySynth(Tone.Synth, {
          oscillator: { type: "sawtooth" },
          envelope: { attack: 0.001, decay: 0.18, sustain: 0, release: 0.1 }
        }).toDestination();
        weaponSynth.volume.value = -4;

        // Monster roar/growl synth (Deep distorted pitch slide)
        const dist = new Tone.Distortion(0.8).toDestination();
        monsterGrowlSynth = new Tone.MonoSynth({
          oscillator: { type: "fmsawtooth" },
          envelope: { attack: 0.1, decay: 1.2, sustain: 0.4, release: 1.5 }
        }).connect(dist);
        monsterGrowlSynth.volume.value = -6;

        // High-tech UI click synth
        clickSynth = new Tone.MembraneSynth({
          pitchDecay: 0.01,
          octaves: 2,
          envelope: { attack: 0.001, decay: 0.05, sustain: 0, release: 0.05 }
        }).toDestination();
        clickSynth.volume.value = -12;

        audioReady = true;
      } catch (e) {
        console.warn("Tone audio init warning:", e);
      }
    }

    // Play gunshot SFX
    function playGunshotSound() {
      if (!audioReady) return;
      try {
        weaponSynth.triggerAttackRelease(["C2", "G1", "C1"], "16n");
      } catch (e) {}
    }

    // Play monster growl SFX
    function playMonsterGrowl() {
      if (!audioReady) return;
      try {
        monsterGrowlSynth.triggerAttackRelease("D1", "1.5s");
      } catch (e) {}
    }

    // --- State Variables ---
    let ammo = 36;
    const maxAmmo = 45;
    let isReloading = false;
    let nightVisionActive = false;
    let thermalVisionActive = false;
    let flashlightActive = true;

    // --- DOM Elements ---
    const ammoCountEl = document.getElementById('current-ammo');
    const ammoBarEl = document.getElementById('ammo-bar');
    const crosshairEl = document.getElementById('crosshair-ui');
    const visionLayer = document.getElementById('vision-mode-layer');
    const alarmBorder = document.getElementById('alarm-border');
    const monsterDistEl = document.getElementById('monster-distance');
    const compassDegEl = document.getElementById('compass-deg');

    // UI Buttons
    const btnFire = document.getElementById('btn-fire');
    const btnReload = document.getElementById('btn-reload');
    const btnNVG = document.getElementById('btn-nvg');
    const btnThermal = document.getElementById('btn-thermal');
    const btnLight = document.getElementById('btn-light');
    const btnEnter = document.getElementById('btn-enter');
    const audioModal = document.getElementById('audio-init-modal');

    btnEnter.addEventListener('click', () => {
      initAudio();
      audioModal.classList.add('hidden');
      setTimeout(playMonsterGrowl, 1000);
    });

    // --- Three.js Realistic Dark Sci-Fi Scene Setup ---
    const container = document.getElementById('canvas-container');
    const scene = new THREE.Scene();
    scene.background = new THREE.Color(0x020408);
    scene.fog = new THREE.FogExp2(0x020408, 0.055);

    const camera = new THREE.PerspectiveCamera(72, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.set(0, 1.6, 2.5);

    const renderer = new THREE.WebGLRenderer({ antialias: true, alpha: false, powerPreference: "high-performance" });
    renderer.setSize(window.innerWidth, window.innerHeight);
    renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));
    renderer.shadowMap.enabled = true;
    renderer.shadowMap.type = THREE.PCFSoftShadowMap;
    renderer.toneMapping = THREE.ACESFilmicToneMapping;
    renderer.toneMappingExposure = 1.1;
    container.appendChild(renderer.domElement);

    // --- Procedural Sci-Fi Corridor Environment ---
    // Metallic Rough Material for Walls & Ceilings
    const wallMaterial = new THREE.MeshStandardMaterial({
      color: 0x181c24,
      roughness: 0.65,
      metalness: 0.85
    });

    const floorMaterial = new THREE.MeshStandardMaterial({
      color: 0x0f131a,
      roughness: 0.35,
      metalness: 0.9
    });

    // Floor Mesh (Industrial Metal Grid)
    const floorGeo = new THREE.PlaneGeometry(12, 60, 30, 60);
    const floor = new THREE.Mesh(floorGeo, floorMaterial);
    floor.rotation.x = -Math.PI / 2;
    floor.position.z = -15;
    floor.receiveShadow = true;
    scene.add(floor);

    // Ceiling
    const ceilingGeo = new THREE.PlaneGeometry(12, 60);
    const ceiling = new THREE.Mesh(ceilingGeo, wallMaterial);
    ceiling.rotation.x = Math.PI / 2;
    ceiling.position.y = 4.2;
    ceiling.position.z = -15;
    scene.add(ceiling);

    // Left & Right Walls
    const wallGeo = new THREE.PlaneGeometry(60, 4.2);
    const leftWall = new THREE.Mesh(wallGeo, wallMaterial);
    leftWall.position.set(-6, 2.1, -15);
    leftWall.rotation.y = Math.PI / 2;
    leftWall.receiveShadow = true;
    scene.add(leftWall);

    const rightWall = new THREE.Mesh(wallGeo, wallMaterial);
    rightWall.position.set(6, 2.1, -15);
    rightWall.rotation.y = -Math.PI / 2;
    rightWall.receiveShadow = true;
    scene.add(rightWall);

    // Structural Pillars / Corridor Arches & Pipes
    const pillarsGroup = new THREE.Group();
    for (let i = 0; i > -45; i -= 5) {
      // Arched Beam
      const archGeo = new THREE.BoxGeometry(0.5, 4.2, 0.4);
      const leftPillar = new THREE.Mesh(archGeo, wallMaterial);
      leftPillar.position.set(-5.7, 2.1, i);
      leftPillar.castShadow = true;

      const rightPillar = leftPillar.clone();
      rightPillar.position.x = 5.7;

      const topPillarGeo = new THREE.BoxGeometry(11.8, 0.4, 0.4);
      const topPillar = new THREE.Mesh(topPillarGeo, wallMaterial);
      topPillar.position.set(0, 4.0, i);

      // Neon Conduit Strips on ceiling
      const stripGeo = new THREE.BoxGeometry(0.08, 0.05, 4.8);
      const stripMat = new THREE.MeshBasicMaterial({ color: 0x06b6d4 });
      const stripLeft = new THREE.Mesh(stripGeo, stripMat);
      stripLeft.position.set(-2.5, 4.15, i + 2.5);

      const stripRight = stripLeft.clone();
      stripRight.position.x = 2.5;

      pillarsGroup.add(leftPillar, rightPillar, topPillar, stripLeft, stripRight);

      // Industrial wall pipes
      const pipeGeo = new THREE.CylinderGeometry(0.12, 0.12, 5, 8);
      const pipeMat = new THREE.MeshStandardMaterial({ color: 0x334155, metalness: 0.9, roughness: 0.3 });
      const pipe = new THREE.Mesh(pipeGeo, pipeMat);
      pipe.rotation.x = Math.PI / 2;
      pipe.position.set(5.85, 1.2, i + 2.5);
      pillarsGroup.add(pipe);
    }
    scene.add(pillarsGroup);

    // --- Terrifying Biomechanical Alien Monster ---
    // Constructed with glowing organic organs, armored chitin plates, & razor appendages
    const monsterGroup = new THREE.Group();
    monsterGroup.position.set(0, 0, -11.5);

    // Torso / Carapace
    const torsoGeo = new THREE.ConeGeometry(1.2, 2.6, 7);
    const alienSkinMat = new THREE.MeshStandardMaterial({
      color: 0x0a0c10,
      roughness: 0.25,
      metalness: 0.75,
      bumpScale: 0.05
    });
    const torso = new THREE.Mesh(torsoGeo, alienSkinMat);
    torso.position.y = 2.1;
    torso.rotation.x = Math.PI * 0.9;
    torso.castShadow = true;
    monsterGroup.add(torso);

    // Monster Glowing Bio-Core (Bioluminescent Pulses)
    const bioCoreGeo = new THREE.DodecahedronGeometry(0.55, 1);
    const bioCoreMat = new THREE.MeshStandardMaterial({
      color: 0xff0033,
      emissive: 0xff0022,
      emissiveIntensity: 2.2,
      roughness: 0.2
    });
    const bioCore = new THREE.Mesh(bioCoreGeo, bioCoreMat);
    bioCore.position.set(0, 1.9, 0.4);
    monsterGroup.add(bioCore);

    // Monster Head with Razor Horns & Multiple Eyes
    const headGeo = new THREE.SphereGeometry(0.65, 8, 8);
    const head = new THREE.Mesh(headGeo, alienSkinMat);
    head.position.set(0, 2.9, 0.75);
    head.scale.set(0.8, 1.3, 1.2);
    monsterGroup.add(head);

    // Glowing Menacing Eyes
    const eyeGeo = new THREE.SphereGeometry(0.08, 8, 8);
    const eyeMat = new THREE.MeshBasicMaterial({ color: 0xff1100 });
    const eyeL1 = new THREE.Mesh(eyeGeo, eyeMat);
    eyeL1.position.set(-0.25, 3.1, 1.25);
    const eyeR1 = eyeL1.clone();
    eyeR1.position.x = 0.25;

    const eyeL2 = new THREE.Mesh(eyeGeo, eyeMat);
    eyeL2.position.set(-0.15, 2.9, 1.3);
    const eyeR2 = eyeL2.clone();
    eyeR2.position.x = 0.15;
    monsterGroup.add(eyeL1, eyeR1, eyeL2, eyeR2);

    // Sharp Biomechanical Scythe Limbs (Left & Right Arms)
    function createScytheArm(side = 1) {
      const armGroup = new THREE.Group();
      // Shoulder
      const upperGeo = new THREE.CylinderGeometry(0.12, 0.07, 1.6);
      const upper = new THREE.Mesh(upperGeo, alienSkinMat);
      upper.position.set(side * 0.9, 2.4, 0.2);
      upper.rotation.z = side * -0.6;
      upper.rotation.x = -0.4;

      // Razor Forearm
      const bladeGeo = new THREE.ConeGeometry(0.18, 2.2, 4);
      const bladeMat = new THREE.MeshStandardMaterial({
        color: 0x1e293b,
        metalness: 0.95,
        roughness: 0.15,
        emissive: 0x990000,
        emissiveIntensity: 0.3
      });
      const blade = new THREE.Mesh(bladeGeo, bladeMat);
      blade.position.set(side * 1.5, 1.4, 0.8);
      blade.rotation.z = side * 0.8;
      blade.rotation.x = 1.0;

      armGroup.add(upper, blade);
      return armGroup;
    }
    const leftArm = createScytheArm(1);
    const rightArm = createScytheArm(-1);
    monsterGroup.add(leftArm, rightArm);

    // Steam/Spore Particle Mist around Monster
    const sporeCount = 60;
    const sporeGeo = new THREE.BufferGeometry();
    const sporePos = new Float32Array(sporeCount * 3);
    for (let i = 0; i < sporeCount * 3; i += 3) {
      sporePos[i] = (Math.random() - 0.5) * 4;
      sporePos[i + 1] = Math.random() * 3.5;
      sporePos[i + 2] = (Math.random() - 0.5) * 4;
    }
    sporeGeo.setAttribute('position', new THREE.BufferAttribute(sporePos, 3));
    const sporeMat = new THREE.PointsMaterial({
      color: 0xff3344,
      size: 0.08,
      transparent: true,
      opacity: 0.65
    });
    const sporeParticles = new THREE.Points(sporeGeo, sporeMat);
    monsterGroup.add(sporeParticles);

    scene.add(monsterGroup);

    // --- First-Person Weapon Model Overlay (Futuristic Kinetic-Pulse Carbine) ---
    const weaponGroup = new THREE.Group();
    // Gun Body
    const receiverGeo = new THREE.BoxGeometry(0.14, 0.22, 0.9);
    const gunMat = new THREE.MeshStandardMaterial({
      color: 0x11161f,
      roughness: 0.3,
      metalness: 0.9
    });
    const receiver = new THREE.Mesh(receiverGeo, gunMat);

    // Gun Barrel
    const barrelGeo = new THREE.BoxGeometry(0.08, 0.08, 0.7);
    const barrel = new THREE.Mesh(barrelGeo, gunMat);
    barrel.position.set(0, 0.04, -0.65);

    // Top Tactical Rail
    const railGeo = new THREE.BoxGeometry(0.06, 0.04, 0.7);
    const railMat = new THREE.MeshStandardMaterial({ color: 0x06b6d4, emissive: 0x0891b2, emissiveIntensity: 0.5 });
    const rail = new THREE.Mesh(railGeo, railMat);
    rail.position.set(0, 0.13, -0.15);

    // Gun Ammo Counter Holographic Screen (Mounted on weapon)
    const ammoScreenGeo = new THREE.PlaneGeometry(0.09, 0.06);
    const ammoScreenMat = new THREE.MeshBasicMaterial({ color: 0x22d3ee, side: THREE.DoubleSide });
    const ammoScreen = new THREE.Mesh(ammoScreenGeo, ammoScreenMat);
    ammoScreen.position.set(0, 0.16, -0.05);
    ammoScreen.rotation.x = -0.3;

    // Muzzle Flash Mesh (Normally hidden)
    const muzzleGeo = new THREE.DodecahedronGeometry(0.18, 1);
    const muzzleMat = new THREE.MeshBasicMaterial({ color: 0x67e8f9, transparent: true, opacity: 0.9 });
    const muzzleFlash = new THREE.Mesh(muzzleGeo, muzzleMat);
    muzzleFlash.position.set(0, 0.04, -1.05);
    muzzleFlash.visible = false;

    // Tactical Flashlight attached to Weapon
    const weaponLight = new THREE.SpotLight(0xcffafe, 3.8, 35, Math.PI / 6, 0.45, 1.2);
    weaponLight.position.set(0.1, -0.05, -0.5);
    weaponLight.target.position.set(0, 0, -20);
    weaponLight.castShadow = true;

    weaponGroup.add(receiver, barrel, rail, ammoScreen, muzzleFlash, weaponLight, weaponLight.target);

    // Place Weapon in 1st Person Camera Space
    weaponGroup.position.set(0.34, -0.28, -0.65);
    camera.add(weaponGroup);
    scene.add(camera);

    // --- Lighting Setup ---
    // Ambient Low Light for Deep Horror Vibe
    const ambientLight = new THREE.AmbientLight(0x0a1120, 0.6);
    scene.add(ambientLight);

    // Creepy Flickering Emergency Red Corridor Light near Monster
    const alarmLight = new THREE.PointLight(0xff1e1e, 2.5, 16);
    alarmLight.position.set(0, 3.8, -12);
    alarmLight.castShadow = true;
    scene.add(alarmLight);

    // Distant Neon Cyan Accent Light
    const neonAccentLight = new THREE.PointLight(0x06b6d4, 1.8, 20);
    neonAccentLight.position.set(-3.5, 2.5, -4);
    scene.add(neonAccentLight);

    // --- Interactive Controls & Weapon Handling ---
    let isFiring = false;
    let weaponRecoil = 0;
    let targetCameraRot = { x: 0, y: 0 };

    // Mouse Look / Aiming Swivel
    window.addEventListener('mousemove', (e) => {
      const mouseX = (e.clientX / window.innerWidth) * 2 - 1;
      const mouseY = (e.clientY / window.innerHeight) * 2 - 1;

      targetCameraRot.y = -mouseX * 0.18;
      targetCameraRot.x = -mouseY * 0.12;

      // Update HUD reticle slight sway
      crosshairEl.style.transform = `translate(${mouseX * 25}px, ${mouseY * 20}px)`;

      // Compass Heading Update
      const deg = Math.floor(((mouseX + 1) / 2) * 20);
      compassDegEl.textContent = `${deg < 10 ? '00' : '0'}${deg}°`;
    });

    // Fire Function
    function shootWeapon() {
      if (ammo <= 0 || isReloading) {
        if (audioReady) clickSynth.triggerAttackRelease("C1", "32n");
        return;
      }

      ammo--;
      updateAmmoUI();
      playGunshotSound();

      // Recoil & Muzzle Flash
      weaponRecoil = 0.08;
      muzzleFlash.visible = true;
      muzzleFlash.scale.setScalar(0.8 + Math.random() * 0.6);
      setTimeout(() => { muzzleFlash.visible = false; }, 45);

      // Camera Shake
      camera.rotation.x += 0.015;

      // Reticle UI pulse
      crosshairEl.classList.add('reticle-fire');
      setTimeout(() => crosshairEl.classList.remove('reticle-fire'), 120);

      // Hit effect on monster
      if (Math.random() > 0.4) {
        bioCore.material.emissiveIntensity = 4.5;
        setTimeout(() => bioCore.material.emissiveIntensity = 2.2, 100);
      }
    }

    function reloadWeapon() {
      if (isReloading || ammo === maxAmmo) return;
      isReloading = true;
      if (audioReady) clickSynth.triggerAttackRelease("G2", "16n");

      ammoCountEl.textContent = "--";
      ammoCountEl.classList.add('animate-pulse');

      // Weapon drop animation during reload
      const startY = weaponGroup.position.y;
      weaponGroup.position.y = startY - 0.2;

      setTimeout(() => {
        ammo = maxAmmo;
        updateAmmoUI();
        isReloading = false;
        weaponGroup.position.y = startY;
        ammoCountEl.classList.remove('animate-pulse');
        if (audioReady) clickSynth.triggerAttackRelease("C3", "16n");
      }, 1400);
    }

    function updateAmmoUI() {
      ammoCountEl.textContent = ammo < 10 ? `0${ammo}` : ammo;
      const pct = (ammo / maxAmmo) * 100;
      ammoBarEl.style.width = `${pct}%`;
      if (pct < 25) {
        ammoBarEl.className = "h-full bg-red-500 transition-all duration-100";
      } else {
        ammoBarEl.className = "h-full bg-cyan-400 transition-all duration-100";
      }
    }

    // Interactive Trigger Listeners
    window.addEventListener('mousedown', (e) => {
      // Don't fire if clicking interactive UI buttons
      if (e.target.closest('button')) return;
      shootWeapon();
    });

    btnFire.addEventListener('click', (e) => {
      e.stopPropagation();
      shootWeapon();
    });

    btnReload.addEventListener('click', (e) => {
      e.stopPropagation();
      reloadWeapon();
    });

    // Night Vision Toggle
    btnNVG.addEventListener('click', (e) => {
      e.stopPropagation();
      nightVisionActive = !nightVisionActive;
      thermalVisionActive = false;
      if (nightVisionActive) {
        visionLayer.className = "pointer-events-none absolute inset-0 z-10 night-vision-tint opacity-80 transition-opacity duration-200";
        btnNVG.classList.add('bg-emerald-600', 'text-white');
        btnThermal.classList.remove('bg-orange-600', 'text-white');
        scene.fog.color.setHex(0x063311);
      } else {
        visionLayer.style.opacity = '0';
        btnNVG.classList.remove('bg-emerald-600', 'text-white');
        scene.fog.color.setHex(0x020408);
      }
    });

    // Thermal Vision Toggle
    btnThermal.addEventListener('click', (e) => {
      e.stopPropagation();
      thermalVisionActive = !thermalVisionActive;
      nightVisionActive = false;
      if (thermalVisionActive) {
        visionLayer.className = "pointer-events-none absolute inset-0 z-10 thermal-vision-tint opacity-75 transition-opacity duration-200";
        btnThermal.classList.add('bg-orange-600', 'text-white');
        btnNVG.classList.remove('bg-emerald-600', 'text-white');
        scene.fog.color.setHex(0x19082b);
      } else {
        visionLayer.style.opacity = '0';
        btnThermal.classList.remove('bg-orange-600', 'text-white');
        scene.fog.color.setHex(0x020408);
      }
    });

    // Tactical Flashlight Toggle
    btnLight.addEventListener('click', (e) => {
      e.stopPropagation();
      flashlightActive = !flashlightActive;
      weaponLight.intensity = flashlightActive ? 3.8 : 0.0;
      btnLight.classList.toggle('opacity-50', !flashlightActive);
    });

    // Keyboard Shortcuts
    window.addEventListener('keydown', (e) => {
      if (e.code === 'KeyR') reloadWeapon();
      if (e.code === 'KeyN') btnNVG.click();
      if (e.code === 'KeyT') btnThermal.click();
      if (e.code === 'KeyF') btnLight.click();
    });

    // --- Main Animation & Simulation Loop ---
    let clock = new THREE.Clock();

    function animate() {
      requestAnimationFrame(animate);

      const elapsedTime = clock.getElapsedTime();

      // Camera Smooth Look-At Interpolation
      camera.rotation.y += (targetCameraRot.y - camera.rotation.y) * 0.08;
      camera.rotation.x += (targetCameraRot.x - camera.rotation.x) * 0.08;

      // Weapon Idle Breathing & Recoil Recovery
      weaponGroup.position.y += ((-0.28 + Math.sin(elapsedTime * 2.5) * 0.005) - weaponGroup.position.y) * 0.1;
      weaponGroup.position.x += ((0.34 + Math.cos(elapsedTime * 1.5) * 0.004) - weaponGroup.position.x) * 0.1;
      if (weaponRecoil > 0) {
        weaponGroup.position.z += weaponRecoil;
        weaponRecoil *= 0.55;
      } else {
        weaponGroup.position.z += (-0.65 - weaponGroup.position.z) * 0.15;
      }

      // Monster Menacing Movement & Aggressive Breathing
      const monsterLurch = Math.sin(elapsedTime * 2.8) * 0.15;
      monsterGroup.position.y = monsterLurch;
      torso.rotation.z = Math.sin(elapsedTime * 1.8) * 0.06;
      head.rotation.y = Math.sin(elapsedTime * 3.2) * 0.15;

      // Scythe Arms Menacing Wave
      leftArm.rotation.z = Math.sin(elapsedTime * 3) * 0.1;
      rightArm.rotation.z = -Math.sin(elapsedTime * 3) * 0.1;

      // Spore mist slow spin
      sporeParticles.rotation.y = elapsedTime * 0.2;

      // Emergency Light Flickering
      alarmLight.intensity = 2.0 + Math.sin(elapsedTime * 7.0) * 1.6;

      // Dynamic Threat Proximity simulation
      const currentDist = (14.2 + Math.sin(elapsedTime * 0.8) * 2.8).toFixed(1);
      monsterDistEl.textContent = `DIST: ${currentDist} M`;

      // Border Alert Pulse
      const alarmFactor = Math.abs(Math.sin(elapsedTime * 3.5));
      alarmBorder.style.borderColor = `rgba(239, 68, 68, ${alarmFactor * 0.4})`;

      renderer.render(scene, camera);
    }

    // --- Responsive Canvas Resizing ---
    window.addEventListener('resize', () => {
      camera.aspect = window.innerWidth / window.innerHeight;
      camera.updateProjectionMatrix();
      renderer.setSize(window.innerWidth, window.innerHeight);
    });

    // Start on load
    window.onload = () => {
      animate();
    };
  </script>
</body>
</html>