using System;
using System.Collections.Generic;
using System.Text;

namespace SquadMakerAlgorithm
{
    public interface IAlgorithmSequenceDataProvider
    {
        IEnumerable<AlgDynamicSequenceModel> ProvideSequenceData(AlgorithmInput algorithmInput);
    }
}
