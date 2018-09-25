////////////////////////////////////////////////////////////////////////////////////
// File: TimeProfiler.cpp
// Authors: Jim Merrell
// Company: SCI Institute, Univerity of Utah
// Purpose: 
////////////////////////////////////////////////////////////////////////////////////

#include <TimeProfiler.h>

TimeProfiler* TimeProfiler::instance = nullptr;

TimeProfiler::TimeProfiler()
{
	for (size_t i = 0; i < NUM_CPU_TIMERS; ++i)
	{
		SimpleTimer timer;
		m_Timers.push_back(timer);
		m_Counters[i] = 0;
	}
}

TimeProfiler::~TimeProfiler()
{
}

TimeProfiler* TimeProfiler::GetInstance()
{
	if (instance == nullptr)
	{
		instance = new TimeProfiler();
	}

	return instance;
}

void TimeProfiler::StartTimer(TIMER_NAMES timerName)
{
	m_Timers[timerName].Start();
	m_Counters[timerName] += 1;

//#ifdef VERBOSE_TIMING_INFO
//    printf("Starting  Timer %-30s %s\n", TimerStrings[(int)timerName], m_Timers[(int)timerName].GetTotalClockTime());
//#endif
}

void TimeProfiler::StopTimer(TIMER_NAMES timerName)
{
	m_Timers[timerName].Stop();

//#ifdef VERBOSE_TIMING_INFO
//    printf("Finishing Timer %-30s %12.3f(sec)\n", TimerStrings[(int)timerName],
//           m_Timers[(int)timerName].GetTotalClockTime());
//#endif
}

void TimeProfiler::AddTick(TIMER_NAMES timerName)
{
	m_Counters[timerName] += 1;
}

SimpleTimer TimeProfiler::GetTimer(TIMER_NAMES timerName) const
{
	return m_Timers[timerName];
}

void TimeProfiler::WriteTimerDataToFile(std::string filename)
{
	FILE* outFile;
	outFile = fopen(filename.c_str(), "w");
	fprintf(outFile, "\n\nTiming information:\n\n");
	
	for (int i = 0; i < NUM_CPU_TIMERS; ++i)
	{
		fprintf(outFile,
			"%-80s: Total:%12.3f(s) Counter:%d\n",
			TimerStrings[i],
			m_Timers[i].GetTotalClockTime(),
			m_Counters[i]
		);
	}
	
	fclose(outFile);
}
