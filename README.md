# BaldiMods
BaldiMods is a DLL containing various mods for Baldi's Basics in Education and Learning
The code is designed to provide a platform that mods can be built upon.
# Developing
When working with this code, there's a few things you should know.
## Hooks
The hooks namespace is designed for hooks from Baldi classes. Baldi's basics doesn't use namespaces, so they can all be stored under the Hooks namespace. Additionally, every class used from the game should be recreated in the mod dll with the same name, any methods reconstructed or hooked should also use the same name. 
Hooks currently created with ILSpy and Reflexil, and modified game binaries are stored in the Baldi directory. These should be minimal, and no unnecessary assets should be distributed. However since the game is available and distributed for free, I see no problem including modified files here. Ideally the hooks would be patched in memory.
## Components
The ComponentFactory class can be used to instance MonoBehaviour components. MonoBehaviours provide access to all of Unity's event functions like Start(), Update() and FixedUpdate(). The ModComponentAttribute can be used to register a component to the factory. Components without this attribute will not be automatically instanced.
## Overriding Classes
Overriden classes should be implemented in the Override namespace, and derive when suitable. Including decompiled code should be avoided. Private fields in game base classes can be modified to public using ILSpy and Reflexil. The OverrideComponentAttribute includes some basic code for disabling old components, and adding override components, but this needs expanding upon. A callback would be useful for example, and deriving overrides might want to replace.
# Building
The project requires Unity and Baldi dlls. Personally I store these in BaldiLibs and UnityLibs. These aren't included, but they're available in baldi\BALDI_Data\Managed.
After referencing required libraries, the BaldiMods DLL can be built with VisualStudio 2017.
The modified game assets inside the Baldi folder should be moved into the game install, overwriting any conflicts, and the BaldiMods.dll file should be moved to baldi\BALDI_Data\Managed.
# Todo
 * Create a config for choosing mod components.
 * Implement more debug features.
 * Patch hooks in memory.
 * Add Logger.
 * Implement more component types (like game scene component).