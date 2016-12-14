//namespace AdventOfCode
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//
//    public class BitwiseCircuit
//    {
//        public List<Mapping> Mappings { get; set;  }
//
//        private string[] _posTwoOperators = { "AND", "OR", "LSHIFT", "RSHIFT" };
//
//        private const string PosOneOperator = "NOT";
//
//        public BitwiseCircuit()
//        {
//            Mappings = new List<Mapping>();
//        }
//
//        public void FollowInstructions(string instructions)
//        {
//            var splitInstructions = instructions.Split('\n');
//
//            foreach (var splitInstruction in splitInstructions)
//            {
//                Interpret(splitInstruction);
//            }
//
//            foreach (var mapping in Mappings)
//            {
//                Evaluate(mapping);
//            }
//        }
//
//        private void Interpret(string instr)
//        {
//            var instructionSplit = instr.Split(' ');
//
//            if (_posTwoOperators.Any(o => instructionSplit[1] == o))
//            {
//                DoPosTwoOps(instructionSplit);
//            }
//            else if (instructionSplit[0] == PosOneOperator)
//            {
//                DoNot(instructionSplit);
//            }
//            else
//            {
//                DoAssign(instructionSplit);
//            }
//        }
//
//        private void DoPosTwoOps(string[] ops)
//        {
//            int dummy;
//            switch (ops[1])
//            {
//                case "AND":
//                    if (!int.TryParse(ops[0].Trim(), out dummy))
//                    {
//                        Mappings.Add(
//                            new Mapping
//                            {
//                                LeftInputNodeName = ops[0].Trim(),
//                                Op = Operation.AND,
//                                RightInputNodeName = ops[2].Trim(),
//                                ThisNodeName = ops[4].Trim(),
//                                IsEvaluated = false
//                            });
//                    }
//                    else
//                    {
//                        Mappings.Add(
//                            new Mapping
//                            {
//                                LeftInputNum = dummy,
//                                Op = Operation.AND,
//                                RightInputNodeName = ops[2].Trim(),
//                                ThisNodeName = ops[4].Trim(),
//                                IsEvaluated = false
//                            });
//                    }
//                    break;
//                case "OR":
//                    if (!int.TryParse(ops[0].Trim(), out dummy))
//                    {
//                        Mappings.Add(
//                            new Mapping
//                            {
//                                LeftInputNodeName = ops[0].Trim(),
//                                Op = Operation.OR,
//                                RightInputNodeName = ops[2].Trim(),
//                                ThisNodeName = ops[4].Trim(),
//                                IsEvaluated = false
//                            });
//                    }
//                    else
//                    {
//                        Mappings.Add(
//                            new Mapping
//                            {
//                                LeftInputNum = dummy,
//                                Op = Operation.OR,
//                                RightInputNodeName = ops[2].Trim(),
//                                ThisNodeName = ops[4].Trim(),
//                                IsEvaluated = false
//                            });
//                    }
//                    break;
//                case "LSHIFT":
//                    Mappings.Add(new Mapping
//                    {
//                        LeftInputNodeName = ops[0].Trim(),
//                        Op = Operation.LSHIFT,
//                        ShiftAmount = int.Parse(ops[2]),
//                        ThisNodeName = ops[4].Trim(),
//                        IsEvaluated = false
//                    });
//                    break;
//                case "RSHIFT":
//                    Mappings.Add(new Mapping
//                    {
//                        LeftInputNodeName = ops[0].Trim(),
//                        Op = Operation.RSHIFT,
//                        ShiftAmount = int.Parse(ops[2].Trim()),
//                        ThisNodeName = ops[4].Trim(),
//                        IsEvaluated = false
//                    });
//                    break;
//            }
//        }
//
//        private void DoNot(string[] ops)
//        {
//            Mappings.Add(new Mapping
//            {
//                LeftInputNodeName = ops[1].Trim(),
//                Op = Operation.NOT,
//                ThisNodeName = ops[3].Trim(),
//                IsEvaluated = false
//            });
//        }
//
//        private void DoAssign(string[] ops)
//        {
//            int val;
//            if (int.TryParse(ops[0].Trim(), out val))
//            {
//                Mappings.Add(
//                    new Mapping
//                    {
//                        Op = Operation.ASSIGN,
//                        EvaluatedValue = val,
//                        ThisNodeName = ops[2].Trim(),
//                        IsEvaluated = true
//                    });
//            }
//
//            else
//            {
//                Mappings.Add(
//                    new Mapping
//                    {
//                        Op = Operation.ASSIGN,
//                        ThisNodeName = ops[2].Trim(),
//                        LeftInputNodeName = ops[0].Trim(),
//                        IsEvaluated = false
//                    });
//            }
//        }
//
//        public void Evaluate(Mapping mapping)
//        {
//            switch (mapping.Op)
//            {
//                case Operation.ASSIGN:
//                    EvalAssign(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//                case Operation.AND:
//                    EvalAnd(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//                case Operation.OR:
//                    EvalOr(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//                case Operation.NOT:
//                    EvalNot(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//                case Operation.LSHIFT:
//                    EvalLshift(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//                case Operation.RSHIFT:
//                    EvalRshift(mapping);
//                    mapping.IsEvaluated = true;
//                    break;
//            }
//        }
//
//        public void EvalAnd(Mapping mapping)
//        {
//            var leftIn = Mappings.SingleOrDefault(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (leftIn != null && !leftIn.IsEvaluated && leftIn.LeftInputNum == null)
//            {
//                Evaluate(leftIn);
//            }
//
//            var rightIn = Mappings.Single(m => m.ThisNodeName == mapping.RightInputNodeName);
//
//            if (!rightIn.IsEvaluated)
//            {
//                Evaluate(rightIn);
//            }
//
//            if (mapping.LeftInputNum == null)
//            {
//                mapping.EvaluatedValue = leftIn.EvaluatedValue.Value & rightIn.EvaluatedValue.Value;
//            }
//            else
//            {
//                mapping.EvaluatedValue = mapping.LeftInputNum & rightIn.EvaluatedValue.Value;
//            }
//        }
//
//        public void EvalOr(Mapping mapping)
//        {
//            var leftIn = Mappings.SingleOrDefault(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (leftIn != null && !leftIn.IsEvaluated && leftIn.LeftInputNum == null)
//            {
//                Evaluate(leftIn);
//            }
//
//            var rightIn = Mappings.Single(m => m.ThisNodeName == mapping.RightInputNodeName);
//
//            if (!rightIn.IsEvaluated)
//            {
//                Evaluate(rightIn);
//            }
//
//            if (mapping.LeftInputNum == null)
//            {
//                mapping.EvaluatedValue = leftIn.EvaluatedValue.Value | rightIn.EvaluatedValue.Value;
//            }
//            else
//            {
//                mapping.EvaluatedValue = mapping.LeftInputNum | rightIn.EvaluatedValue.Value;
//            }
//        }
//
//        public void EvalNot(Mapping mapping)
//        {
//            var leftIn = Mappings.Single(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (!leftIn.IsEvaluated)
//            {
//                Evaluate(leftIn);
//            }
//
//            mapping.EvaluatedValue = ~leftIn.EvaluatedValue.Value;
//        }
//
//        public void EvalLshift(Mapping mapping)
//        {
//            var leftIn = Mappings.SingleOrDefault(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (leftIn != null && !leftIn.IsEvaluated && mapping.LeftInputNum == null)
//            {
//                Evaluate(leftIn);
//            }
//            if (mapping.LeftInputNum == null)
//            {
//                mapping.EvaluatedValue = leftIn.EvaluatedValue.Value << mapping.ShiftAmount.Value;
//            }
//            else
//            {
//                mapping.EvaluatedValue = mapping.LeftInputNum.Value << mapping.ShiftAmount.Value;
//            }
//        }
//
//        public void EvalRshift(Mapping mapping)
//        {
//            var leftIn = Mappings.SingleOrDefault(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (leftIn != null && !leftIn.IsEvaluated && mapping.LeftInputNum == null)
//            {
//                Evaluate(leftIn);
//            }
//            if (mapping.LeftInputNum == null)
//            {
//                mapping.EvaluatedValue = leftIn.EvaluatedValue.Value >> mapping.ShiftAmount.Value;
//            }
//            else
//            {
//                mapping.EvaluatedValue = mapping.LeftInputNum.Value >> mapping.ShiftAmount.Value;
//            }
//        }
//
//        public void EvalAssign(Mapping mapping)
//        {
//            Mapping leftIn = Mappings.SingleOrDefault(m => m.ThisNodeName == mapping.LeftInputNodeName);
//
//            if (leftIn != null && !leftIn.IsEvaluated && mapping.LeftInputNum == null)
//            {
//                Evaluate(leftIn);
//            }
//            if (mapping.LeftInputNum == null && leftIn != null)
//            {
//                mapping.EvaluatedValue = leftIn.EvaluatedValue.Value;
//            }
//            else if (mapping.LeftInputNum == null)
//            {
//                mapping.IsEvaluated = true;
//            }
//            else
//            {
//                mapping.EvaluatedValue = mapping.LeftInputNum.Value;
//            }
//        }
//    }
//
//    public class Mapping
//    {
//        public string ThisNodeName { get; set; }
//
//        public Operation Op { get; set; }
//
//        public int? ShiftAmount { get; set; }
//
//        public string LeftInputNodeName { get; set; }
//
//        public string RightInputNodeName { get; set; }
//
//        public int? InputValue { get; set; }
//
//        public int? EvaluatedValue { get; set; }
//
//        public bool IsEvaluated { get; set; }
//
//        public int? LeftInputNum { get; set; }
//
//        public int? RightInputNum { get; set; }
//    }
//
//    public static class Extensions
//    {
//
//    }
//
//    public class Node
//    {
//        public Node(string name, int value)
//        {
//            NodeName = name;
//            NodeValue = value;
//        }
//
//        public Node(string name)
//        {
//            NodeName = name;
//        }
//
//        public string NodeName { get; set; }
//
//        public int NodeValue { get; set; }
//    }
//
//    public enum Operation
//    {
//        AND,
//        OR,
//        LSHIFT,
//        RSHIFT,
//        NOT,
//        ASSIGN
//    }
//}