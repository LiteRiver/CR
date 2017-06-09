using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public static class Metro2Options {
        private static List<Option> m_portfolioType;

        public static List<Option> PortfolioType {
            get {
                if (m_portfolioType == null) {
                    m_portfolioType = new List<Option>() {
                        new Option("I", "[I] Installment"),
                        new Option("C", "[C] Line of Credit"),
                        new Option("M", "[M] Mortgage"),
                        new Option("O", "[O] Open"),
                        new Option("R", "[R] Revolving")
                    };
                }

                return m_portfolioType;
            }
        }

        private static List<Option> m_accountType;

        public static List<Option> AccountType {
            get {
                if (m_accountType == null) {
                    m_accountType = new List<Option>() {
                        new Option("00", "[00] Auto" ),
                        new Option("01", "[01] Unsecured"),
                        new Option("02", "[02] Secured"),
                        new Option("12", "[12] Education"),
                        new Option("13", "[13] Lease")
                    };
                }

                return m_accountType;
            }
        }

        private static List<Option> m_termsFrequency;

        public static List<Option> TermsFrequency {
            get {
                if (m_termsFrequency == null) {
                    m_termsFrequency = new List<Option>() {
                        new Option("D", "[D] Deferred"),
                        new Option("P", "[P] Single Payment Loan"),
                        new Option("W", "[W] Weekly"),
                        new Option("B", "[B] Biweekly"),
                        new Option("E", "[E] Semimonthly"),
                        new Option("M", "[M] Monthly"),
                        new Option("L", "[L] Bimonthly"),
                        new Option("Q", "[Q] Quarterly"),
                        new Option("T", "[T] Tri-annually"),
                        new Option("S", "[T] Semiannually"),
                        new Option("Y", "[Y] Annually")
                    };
                }

                return m_termsFrequency;
            }
        }

        private static List<Option> m_accountStatus;

        public static List<Option> AccountStatus {
            get {
                if (m_accountStatus == null) {
                    m_accountStatus = new List<Option>() {
                        new Option("05", "[05] Account transferred"),
                        new Option("11", "[11] 0-29 days past the due date"),
                        new Option("13", "[13] Paid off"),
                        new Option("71", "[71] 30-59 days past the due date"),
                        new Option("78", "[78] 60-89 days past the due date"),
                        new Option("80", "[80] 90-119 days past the due date"),
                        new Option("82", "[82] 120-149 days past the due date"),
                        new Option("83", "[83] 150-179 days past the due date"),
                        new Option("84", "[84] 180 days or more past the due date"),
                    };
                }

                return m_accountStatus;
            }
        }

        private static List<Option> m_paymentRating;

        public static List<Option> PaymentRating {
            get {
                if (m_paymentRating == null) {
                    m_paymentRating = new List<Option>() {
                        new Option("", ""),
                        new Option("0", "[0] 0–29 days past the due date"),
                        new Option("1", "[1] 30-59 days past the due date"),
                        new Option("2", "[2] 60-89 days past the due date"),
                        new Option("3", "[3] 90-119 days past the due date"),
                        new Option("4", "[4] 120-149 days past the due date"),
                        new Option("5", "[5] 150-179 days past the due date"),
                        new Option("6", "[6] 180 or more days past the due date"),
                        new Option("G", "[G] Collection"),
                        new Option("L", "[L] Charge-off")
                    };
                }

                return m_paymentRating;
            }
        }

        private static List<Option> m_paymentHistoryProfile;

        public static List<Option> PaymentHistoryProfile {
            get {
                if (m_paymentHistoryProfile == null) {
                    m_paymentHistoryProfile = new List<Option>() {
                        new Option("0", "[0] 0 payments past due (current account)"),
                        new Option("1", "[1] 30 - 59 days past due date"),
                        new Option("2", "[2] 60 - 89 days past due date"),
                        new Option("3", "[3] 90 - 119 days past due date"),
                        new Option("4", "[4] 120 - 149 days past due date"),
                        new Option("5", "[5] 150 - 179 days past due date"),
                        new Option("6", "[6] 180 or more days past due date"),
                        new Option("B", "[B] No payment history available prior to this time"),
                        new Option("D", "[D] No payment history available this month"),
                        new Option("G", "[G] Collection"),
                        new Option("L", "[L] Charge-off")
                    };
                }

                return m_paymentHistoryProfile;
            }
        }

        private static List<Option> m_interestTypeIndicator;

        public static List<Option> InterestTypeIndicator {
            get {
                if (m_interestTypeIndicator == null) {
                    m_interestTypeIndicator = new List<Option>() {
                        new Option("F", "[F] Fixed"),
                        new Option("V", "[V] Variable/Adjustable")
                    };
                }

                return m_interestTypeIndicator;
            }
        }

        private static List<Option> m_state;

        public static List<Option> State {
            get {
                if (m_state == null) {
                    m_state = new List<Option>() {
                        new Option("AL", "AL"),
                        new Option("AK", "AK"),
                        new Option("AZ", "AZ"),
                        new Option("AR", "AR"),
                        new Option("CA", "CA"),
                        new Option("CO", "CO"),
                        new Option("CT", "CT"),
                        new Option("DE", "DE"),
                        new Option("FL", "FL"),
                        new Option("GA", "GA"),
                        new Option("HI", "HI"),
                        new Option("ID", "ID"),
                        new Option("IL", "IL"),
                        new Option("IN", "IN"),
                        new Option("IA", "IA"),
                        new Option("KS", "KS"),
                        new Option("KY", "KY"),
                        new Option("LA", "LA"),
                        new Option("ME", "ME"),
                        new Option("MD", "MD"),
                        new Option("MA", "MA"),
                        new Option("MI", "MI"),
                        new Option("MN", "MN"),
                        new Option("MS", "MS"),
                        new Option("MO", "MO"),
                        new Option("MT", "MT"),
                        new Option("NE", "NE"),
                        new Option("NV", "NV"),
                        new Option("NH", "NH"),
                        new Option("NJ", "NJ"),
                        new Option("NM", "NM"),
                        new Option("NY", "NY"),
                        new Option("NC", "NC"),
                        new Option("ND", "ND"),
                        new Option("OH", "OH"),
                        new Option("OK", "OK"),
                        new Option("OR", "OR"),
                        new Option("PA", "PA"),
                        new Option("RI", "RI"),
                        new Option("SC", "SC"),
                        new Option("SD", "SD"),
                        new Option("TN", "TN"),
                        new Option("TX", "TX"),
                        new Option("UT", "UT"),
                        new Option("VT", "VT"),
                        new Option("VA", "VA"),
                        new Option("WA", "WA"),
                        new Option("WV", "WV"),
                        new Option("WI", "WI"),
                        new Option("WY", "WY")
                    };
                }

                return m_state;
            }
        }

        private static List<Option> m_residenceCode;

        public static List<Option> ResidenceCode {
            get {
                if (m_residenceCode == null) {
                    m_residenceCode = new List<Option>() {
                        new Option("", ""),
                        new Option("O", "[O] Owns"),
                        new Option("R", "[R] Rents")
                    };
                }

                return m_residenceCode;
            }
        }
    }
}
