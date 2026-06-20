// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

// IWYU pragma: private, include "BuffComponent.h"
#include "UObject/ObjectMacros.h"
#include "UObject/ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
#ifdef VERYSERIOUSPROJECT_BuffComponent_generated_h
#error "BuffComponent.generated.h already included, missing '#pragma once' in BuffComponent.h"
#endif
#define VERYSERIOUSPROJECT_BuffComponent_generated_h

#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_22_GENERATED_BODY \
	friend struct Z_Construct_UScriptStruct_FBuff_Statics; \
	VERYSERIOUSPROJECT_API static class UScriptStruct* StaticStruct();


template<> VERYSERIOUSPROJECT_API UScriptStruct* StaticStruct<struct FBuff>();

#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_40_GENERATED_BODY \
	friend struct Z_Construct_UScriptStruct_FDebuff_Statics; \
	VERYSERIOUSPROJECT_API static class UScriptStruct* StaticStruct();


template<> VERYSERIOUSPROJECT_API UScriptStruct* StaticStruct<struct FDebuff>();

#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_58_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesUBuffComponent(); \
	friend struct Z_Construct_UClass_UBuffComponent_Statics; \
public: \
	DECLARE_CLASS(UBuffComponent, UActorComponent, COMPILED_IN_FLAGS(0 | CLASS_Config), CASTCLASS_None, TEXT("/Script/VerySeriousProject"), NO_API) \
	DECLARE_SERIALIZER(UBuffComponent)


#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_58_ENHANCED_CONSTRUCTORS \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	UBuffComponent(UBuffComponent&&); \
	UBuffComponent(const UBuffComponent&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, UBuffComponent); \
	DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(UBuffComponent); \
	DEFINE_DEFAULT_CONSTRUCTOR_CALL(UBuffComponent) \
	NO_API virtual ~UBuffComponent();


#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_55_PROLOG
#define FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_58_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_58_INCLASS_NO_PURE_DECLS \
	FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h_58_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


template<> VERYSERIOUSPROJECT_API UClass* StaticClass<class UBuffComponent>();

#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_BuffComponent_h


#define FOREACH_ENUM_ESTATS(op) \
	op(EStats::None) \
	op(EStats::Speed) \
	op(EStats::Strength) \
	op(EStats::Health) \
	op(EStats::LuckMul) \
	op(EStats::FutureStuff) 

enum class EStats : uint8;
template<> struct TIsUEnumClass<EStats> { enum { Value = true }; };
template<> VERYSERIOUSPROJECT_API UEnum* StaticEnum<EStats>();

PRAGMA_ENABLE_DEPRECATION_WARNINGS
