using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;
using Wasmtime;

namespace WasmMod;

public class WasmMod:ResoniteMod {
	internal const string VERSION = "0.1.0";

	public override string Name => "WasmMod";
	public override string Author => "WattleFoxxo";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/WattleFoxxo/ResoniteWebAssemblyLoader";

	public override void OnEngineInit() {
		Harmony harmony = new Harmony("au.wattlefoxxo.WasmMod");
		harmony.PatchAll();

        // Load WASM module
        using var engine = new Engine();
        using var module = Module.FromTextFile(engine, "gcd.wat");

        using var host = new Host(engine);
        using dynamic instance = host.Instantiate(module);

        // Run WASM module
        int out = instance.gcd(27, 6);
        Console.WriteLine($"gcd(27, 6) = {out}");
	}
}
