// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "VerySeriousProject/Public/TranslateRoomsHUD.h"
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeTranslateRoomsHUD() {}

// Begin Cross Module References
ENGINE_API UClass* Z_Construct_UClass_AHUD();
UPackage* Z_Construct_UPackage__Script_VerySeriousProject();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_ATranslateRoomsHUD();
VERYSERIOUSPROJECT_API UClass* Z_Construct_UClass_ATranslateRoomsHUD_NoRegister();
// End Cross Module References

// Begin Class ATranslateRoomsHUD
void ATranslateRoomsHUD::StaticRegisterNativesATranslateRoomsHUD()
{
}
IMPLEMENT_CLASS_NO_AUTO_REGISTRATION(ATranslateRoomsHUD);
UClass* Z_Construct_UClass_ATranslateRoomsHUD_NoRegister()
{
	return ATranslateRoomsHUD::StaticClass();
}
struct Z_Construct_UClass_ATranslateRoomsHUD_Statics
{
#if WITH_METADATA
	static constexpr UECodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
#if !UE_BUILD_SHIPPING
		{ "Comment", "/**\n * \n */" },
#endif
		{ "HideCategories", "Rendering Actor Input Replication" },
		{ "IncludePath", "TranslateRoomsHUD.h" },
		{ "ModuleRelativePath", "Public/TranslateRoomsHUD.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif // WITH_METADATA
	static UObject* (*const DependentSingletons[])();
	static constexpr FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ATranslateRoomsHUD>::IsAbstract,
	};
	static const UECodeGen_Private::FClassParams ClassParams;
};
UObject* (*const Z_Construct_UClass_ATranslateRoomsHUD_Statics::DependentSingletons[])() = {
	(UObject* (*)())Z_Construct_UClass_AHUD,
	(UObject* (*)())Z_Construct_UPackage__Script_VerySeriousProject,
};
static_assert(UE_ARRAY_COUNT(Z_Construct_UClass_ATranslateRoomsHUD_Statics::DependentSingletons) < 16);
const UECodeGen_Private::FClassParams Z_Construct_UClass_ATranslateRoomsHUD_Statics::ClassParams = {
	&ATranslateRoomsHUD::StaticClass,
	"Game",
	&StaticCppClassTypeInfo,
	DependentSingletons,
	nullptr,
	nullptr,
	nullptr,
	UE_ARRAY_COUNT(DependentSingletons),
	0,
	0,
	0,
	0x009002ACu,
	METADATA_PARAMS(UE_ARRAY_COUNT(Z_Construct_UClass_ATranslateRoomsHUD_Statics::Class_MetaDataParams), Z_Construct_UClass_ATranslateRoomsHUD_Statics::Class_MetaDataParams)
};
UClass* Z_Construct_UClass_ATranslateRoomsHUD()
{
	if (!Z_Registration_Info_UClass_ATranslateRoomsHUD.OuterSingleton)
	{
		UECodeGen_Private::ConstructUClass(Z_Registration_Info_UClass_ATranslateRoomsHUD.OuterSingleton, Z_Construct_UClass_ATranslateRoomsHUD_Statics::ClassParams);
	}
	return Z_Registration_Info_UClass_ATranslateRoomsHUD.OuterSingleton;
}
template<> VERYSERIOUSPROJECT_API UClass* StaticClass<ATranslateRoomsHUD>()
{
	return ATranslateRoomsHUD::StaticClass();
}
ATranslateRoomsHUD::ATranslateRoomsHUD(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer) {}
DEFINE_VTABLE_PTR_HELPER_CTOR(ATranslateRoomsHUD);
ATranslateRoomsHUD::~ATranslateRoomsHUD() {}
// End Class ATranslateRoomsHUD

// Begin Registration
struct Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_TranslateRoomsHUD_h_Statics
{
	static constexpr FClassRegisterCompiledInInfo ClassInfo[] = {
		{ Z_Construct_UClass_ATranslateRoomsHUD, ATranslateRoomsHUD::StaticClass, TEXT("ATranslateRoomsHUD"), &Z_Registration_Info_UClass_ATranslateRoomsHUD, CONSTRUCT_RELOAD_VERSION_INFO(FClassReloadVersionInfo, sizeof(ATranslateRoomsHUD), 2994079337U) },
	};
};
static FRegisterCompiledInInfo Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_TranslateRoomsHUD_h_1792509825(TEXT("/Script/VerySeriousProject"),
	Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_TranslateRoomsHUD_h_Statics::ClassInfo, UE_ARRAY_COUNT(Z_CompiledInDeferFile_FID_VerySeriousJuniperJam_VerySeriousProject_Source_VerySeriousProject_Public_TranslateRoomsHUD_h_Statics::ClassInfo),
	nullptr, 0,
	nullptr, 0);
// End Registration
PRAGMA_ENABLE_DEPRECATION_WARNINGS
