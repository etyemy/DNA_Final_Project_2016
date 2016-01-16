using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    /*
     * Mutation class holds the mutation details.
     * Main purpose - easy transfer of mutation details
     */
    public class Mutation
    {
        //mutation id use as primary key for database, id structure: _chrom_position_ref_var
        private string _mutId;

        //Basic details of mutation, details source from csv file.
        private string _chrom;
        private int _position;
        private string _geneName;
        private char _ref;
        private char _var;

        //Extra details of Mutation, genarated with extractExtraData method
        private List<String> _cosmicDetails;
        private Gene _gene;
        private char _strand;
        private string _chromNum;
        private string _refCodon;
        private string _varCodon;
        private string _varAA;
        private string _refAA;
        private string _pMutationName;
        private string _cMutationName;
        private string _cosmicName;
        private int _numOfShows = 1;

        //First constructor - gets the basic mutation data generate all the extra data, use for new mutation that not exist in local database.
        public Mutation(string chrom, int position, string geneSym, char refNuc, char varNuc)
        {
            _chrom = chrom;
            _chromNum = chrom.Replace("chr", "");
            _position = position;
            _geneName = geneSym;
            _ref = refNuc;
            _var = varNuc;
            _mutId = this.generateMutId();
            try
            {
                extractExtraData();
                if (!MainBL.mutationExist(this))
                    MainBL.addMutation(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Second constructor - gets all mutation details, use for known mutation that exit in local database.
        public Mutation(string mutId, string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName)
        {
            _mutId = mutId;
            _chrom = chrom;
            _position = position;
            _geneName = geneName;
            _ref = refNuc;
            _var = varNuc;
            _strand = strand;
            _chromNum = chromNum;
            _refCodon = refCodon;
            _varCodon = varCodon;
            _refAA = refAA;
            _varAA = varAA;
            _pMutationName = pMutationName;
            _cMutationName = cMutationName;
            _cosmicName = cosmicName;
        }

        //Method that use the basic details of the mutation and generate all extra details.
        public void extractExtraData()
        {
            try
            {
                //get gene details from lodal db, if not exit create new gene and add it to locel db
                _gene = MainBL.getGene(_geneName, _chrom);
                if (_gene == null)
                    _gene = MainBL.addGene(_geneName, _chrom);

                _strand = _gene.Strand;
                if (_strand.Equals('+'))
                    _cosmicDetails = MainBL.getCosmicDetails(_chromNum, _position, _ref, _var);
                else if (_strand.Equals('-'))
                    _cosmicDetails = MainBL.getCosmicDetails(_chromNum, _position, OppositeNuc(_ref), OppositeNuc(_var));

                setVarRefCodons(_gene.getOffsetInCodon(_position));
            }
            catch (Exception)
            {
                throw;
            }
            //sets the rest of the mutation details.
            if (!_refCodon.Equals("No Coding"))
            {
                _varAA = GeneralMethods.getAminoAcid(_varCodon);
                _refAA = GeneralMethods.getAminoAcid(_refCodon);
            }
            else
            {
                _varAA = "-----";
                _refAA = "-----";
            }
            if (_cosmicDetails != null)
            {
                _cosmicName = _cosmicDetails.ElementAt(0);
                _pMutationName = _cosmicDetails.ElementAt(1);
                _cMutationName = _cosmicDetails.ElementAt(2);
            }
            else
            {
                _cosmicName = "-----";
                _pMutationName = "-----";
                _cMutationName = "-----";
            }
        }

        //Method that sets the var codon and the ref codon of the mutation by using _chrom, _position and offset.
        private void setVarRefCodons(int offset)
        {
            if (offset != -1)
            {
                _refCodon = UcscWebServices.getCodonAt(_chrom, _position, offset);

                char[] temp = _refCodon.ToCharArray();
                temp[offset] = _var;
                _varCodon = new string(temp);

                if (_gene.Strand.Equals('-'))
                {
                    _refCodon = GeneralMethods.reverseString(OppositeCodon(_refCodon));
                    _varCodon = GeneralMethods.reverseString(OppositeCodon(_varCodon));
                }
            }
            else
            {
                _refCodon = "No Coding";
                _varCodon = "No Coding";
            }
        }

        //Function that get 3 character string that represent codon, return the oppssite codon, use when strand is '-'.
        private string OppositeCodon(string p)
        {
            string toReturn = "";
            foreach (char c in p)
            {
                switch (c)
                {
                    case 'A':
                        toReturn += "T";
                        break;
                    case 'T':
                        toReturn += "A";
                        break;
                    case 'G':
                        toReturn += "C";
                        break;
                    case 'C':
                        toReturn += "G";
                        break;
                    default:
                        return null;
                }
            }
            return toReturn;
        }

        //Function that get single character that represent nucliotide, return the oppssite nucliotide.
        private char OppositeNuc(char c)
        {
            switch (c)
            {
                case 'A':
                    return 'T';
                case 'T':
                    return 'A';
                case 'G':
                    return 'C';
                case 'C':
                    return 'G';
                default:
                    return ' ';
            }
        }

        //Method that use cosmicId field and return all ids numbers.
        public List<int> getCosmicNums()
        {
            List<int> toReturn = new List<int>();
            string[] cosmicId = _cosmicName.Split(' ');
            foreach (string s in cosmicId)
                toReturn.Add(Convert.ToInt32(Regex.Match(s, @"\d+").Value));
            return toReturn;
        }

        //Method that generate the mutation id.
        private string generateMutId()
        {
            return "" + _chrom + _position + _var + _ref;
        }

        //Function that returns the headers for all tables exporting.
        public static string[] getHeaderForExport()
        {
            return new string[] { "Chromosome", "Position", "Gene Name", "Ref", "Var", "Strand", "Ref Codon", "Var Codon", "Ref AA", "Var AA", "Mutation Name", "Cosmic Details" };
        }
        //Function that returns the mutation details for all tables exporting.
        public string[] getInfoForExport()
        {
            return new string[] { _chrom, _position + "", _geneName, _ref + "", _var + "", _strand + "", _refCodon, _varCodon, _refAA, _varAA, _pMutationName, _cosmicName };
        }

        public string Chrom { get { return _chrom; } }
        public int Position { get { return _position; } }
        public string GeneName { get { return _geneName; } }
        public char Var { get { return _var; } }
        public char Ref { get { return _ref; } }
        public char Strand { get { return _strand; } }
        public string ChromNum { get { return _chromNum; } }
        public string RefCodon { get { return _refCodon; } }
        public string VarCodon { get { return _varCodon; } }
        public string VarAA { get { return _varAA; } }
        public string RefAA { get { return _refAA; } }
        public string PMutationName { get { return _pMutationName; } }
        public string CMutationName { get { return _cMutationName; } }
        public string CosmicName { get { return _cosmicName; } }
        public string MutId { get { return _mutId; } }
        public int NumOfShows
        {
            get { return _numOfShows; }
            set { _numOfShows = value; }
        }
        public Gene Gene
        {
            get
            {
                return _gene;
            }
        }
        public Boolean isCodingInControlArea()
        {
            Gene tempGene;
            if(_gene==null)
                tempGene = MainBL.getGene(_geneName, _chrom);
            else
                tempGene = _gene;

            if (tempGene != null)
            {
                int numberOfExonsInGene = tempGene.ExonStarts.Length;
                if (numberOfExonsInGene != tempGene.ExonEnds.Length)
                {
                    return false;
                }
                for (int i = 0; i < (numberOfExonsInGene - 1); i++)
                {
                    if ((Math.Abs(tempGene.ExonStarts[i] - this._position) <= 10) || (Math.Abs(tempGene.ExonEnds[i] - this._position) <= 10))
                    {
                        return true;
                    }
                } 
            }

            

            return false;
        }
    }
}
