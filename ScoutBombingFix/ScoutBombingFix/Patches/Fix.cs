using Enemies;
using HarmonyLib;

namespace BioScannerFix {
    [HarmonyPatch]
    internal static class Fix {
        [HarmonyPatch(typeof(EnemyDetection), nameof(EnemyDetection.UpdateHibernationDetection))]
        [HarmonyPrefix]
        private static void Prefix_UpdateHibernationDetection(EnemyDetection __instance) {
            if (__instance.m_ai.Agent.CourseNode.m_playerCoverage.GetNodeDistanceToClosestPlayer_Unblocked() > 2) {
                __instance.m_ai.m_behaviourData.Targets.Clear();
                __instance.m_ai.m_behaviourData.m_targetsByID.Clear();
            }
        }
    }
}
