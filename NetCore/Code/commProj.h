#pragma once

#ifdef NETCORE_EXPORTS
#define NETCORE_API __declspec(dllexport)
#else
#define NETCORE_API __declspec(dllimport)
#endif

#ifdef __cplusplus
#define __EXTERN_C  extern "C"
#else
#define __EXTERN_C
#endif

