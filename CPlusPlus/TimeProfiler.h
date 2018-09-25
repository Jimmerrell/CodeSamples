////////////////////////////////////////////////////////////////////////////////////
// File: TimeProfiler.h
// Authors: Jim Merrell
// Company: SCI Institute, Univerity of Utah
// Purpose: 
////////////////////////////////////////////////////////////////////////////////////

#pragma once
#pragma warning(disable : 4820)
#include <vector>
#include <map>

#include "SimpleTimer.h"

class TimeProfiler
{
public:

	enum TIMER_NAMES
	{
		CPU_READ_FROM_EV = 0, 
		CPU_SOLVE_TPS, 
		CPU_UPDATE_RAW_AVAILABLE, 
		CPU_CONSTRUCT_INITIAL_TPS_POINT_SET, 
		CPU_SOLVE_TPS_WITH_INITIAL_SET, 
		CPU_ITERATIVELY_ADD_TPS_POINTS, 
		CPU_SOLVE_FOR_TPS_COEFFS, 
		CPU_CONSTRUCT_TPS_EQUATION_SYSTEM, 
		CPU_TPS_LU_FACTORIZATION, 
		CPU_TPS_SYSTEM_SOLVE, 
		CPU_TPS_POPULATE_SYSTEM_SOLUTION, 
		//CPU_FIND_WORST_THREE_POINTS,
		CPU_FIND_WORST_N_POINTS, 
		CPU_EVALUATE_TPS_ERROR, 
		CPU_ASSIGN_POINT_TO_ORDERED_PAIRS, 
        //CPU_ADD_WORST_THREE_POINTS,
        CPU_ADD_WORST_N_POINTS,
		CPU_SOLVE_CSRBF, 
		CPU_EVALUATE_TPS_RESIDUAL, 
		CPU_CONSTRUCT_CSRBF_POINT_SET, 
		CPU_SOLVE_FOR_CSRBF_COEFFS, 
		CPU_FUNCTION_EVALUATION, 
		CPU_TPS_FUNCTION_EVALUATION, 
		CPU_CSRBF_FUNCTION_EVALUATION, 
		NUM_CPU_TIMERS
	};

	static TimeProfiler* GetInstance();

	//returns an int ID to the index of the new SimpleTimer in m_Timers
	void StartTimer(TIMER_NAMES timerName);
	void StopTimer(TIMER_NAMES timerName);
	void AddTick(TIMER_NAMES timerName);
	SimpleTimer GetTimer(TIMER_NAMES timerName) const;

	void WriteTimerDataToFile(std::string filename);

private:

	TimeProfiler();
	~TimeProfiler();
	TimeProfiler(TimeProfiler const&) {}
	void operator=(TimeProfiler const&) {}

	static TimeProfiler* instance;

	std::vector<SimpleTimer> m_Timers;
	std::map<int, int> m_Counters; // <int ID(key), int Counter(value)>


};

static char TimerStrings[TimeProfiler::TIMER_NAMES::NUM_CPU_TIMERS][200] =
{
	"*(Read EV file)",
	"*(Solve thin plate spline (TPS))",
	"      - Populate raw candidate list",
	"      - Construct initial TPS point set",
	"      - Solve TPS with the initial TPS point set",
	"      - Iteratively add TPS points to acheive the required error",
	"           - Solve for TPS coefficients",
	"               - Construct TPS system of equations",
	"               - LU factorization",
	"               - Solve TPS system of equations using the LU factorization",
	"               - Populate TPS system solution",
	//"           - Find worst three candidate points to be added to the tps points",
	"           - Find worst N candidate points to be added to the tps points",
	"               - Evaluate TPS error",
	"               - Assign point to the correct pairs accroding to its error",
	"           - Add the worst N far enough candidate points to the tps points list",
	"*(Solve compactly supported radial basis function (CSRBF))",
	"      - Compute TPS residual to rank candidate raw point for CSRBF point selection",
	"      - Construct the CSRBF point set",
	"      - Solve for the CSRBF coefficients",
	"*(Total time of implicit function evaluation",
	"      - Evaluate TPS part",
	"      - Evaluate CSRBF part",
};

