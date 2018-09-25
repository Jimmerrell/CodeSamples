#pragma once

class Thread_Optimizer
{
public:
	Thread_Optimizer();
	~Thread_Optimizer();

	// Will test each potential threadCount for the given seconds and return the highest performing threadCount
	int GetOptimalThreadCount(int nMaxThreads, int nSeconds); 

private:
	float m_faWorkerValues[4];
	int m_nWorkerReturn = 0;
	int WorkFunction();
};

