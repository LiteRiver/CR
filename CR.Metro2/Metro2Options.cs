using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public static class Metro2Options {
        public static List<Option> PortfolioType { get; } = new List<Option>() {
            new Option("I", "[I] Installment"),
            new Option("C", "[C] Line of Credit"),
            new Option("M", "[M] Mortgage"),
            new Option("O", "[O] Open"),
            new Option("R", "[R] Revolving")
        };

        public static List<Option> AccountType { get; } = new List<Option>() {
            new Option("00", "[00] Auto" ),
            new Option("01", "[01] Unsecured"),
            new Option("02", "[02] Secured"),
            new Option("12", "[12] Education"),
            new Option("13", "[13] Lease")
        };


        public static List<Option> TermsFrequency { get; } = new List<Option>() {
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

        public static List<Option> AccountStatus { get; } = new List<Option>() {
            new Option("05", "[05] Account transferred"),
            new Option("11", "[11] 0-29 days past the due date"),
            new Option("13", "[13] Paid off"),
            new Option("61", "[61] Account paid in full, was a voluntary surrender"),
            new Option("62", "[62] Account paid in full, was a collection account"),
            new Option("63", "[63] Account paid in full, was a repossession"),
            new Option("64", "[64] Account paid in full, was a charge-off"),
            new Option("65", "[65] Account paid in full. A foreclosure was started"),
            new Option("71", "[71] 30-59 days past the due date"),
            new Option("78", "[78] 60-89 days past the due date"),
            new Option("80", "[80] 90-119 days past the due date"),
            new Option("82", "[82] 120-149 days past the due date"),
            new Option("83", "[83] 150-179 days past the due date"),
            new Option("84", "[84] 180 days or more past the due date"),
            new Option("88", "[88] Claim filed with government for insured portion of balance on a defaulted loan"),
            new Option("89", "[89] Deed received in lieu of foreclosure on a defaulted mortgage"),
            new Option("93", "[93] Account assigned to internal or external collections"),
            new Option("94", "[94] Foreclosure completed"),
            new Option("95", "[95] Voluntary surrender"),
            new Option("96", "[96] Merchandise was repossessed"),
            new Option("97", "[97] Unpaid balance reported as a loss (charge-off)"),
            new Option("DA", "[DA] Delete entire account (for reasons other than fraud)"),
            new Option("DF", "[DF] Delete entire account due to confirmed fraud (fraud investigation completed)")
        };

        public static List<Option> PaymentRating { get; } = new List<Option>() {
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

        public static List<Option> PaymentHistoryProfile { get; } = new List<Option>() {
            new Option("0", "[0] 0 payments past due (current account)"),
            new Option("1", "[1] 30 - 59 days past due date"),
            new Option("2", "[2] 60 - 89 days past due date"),
            new Option("3", "[3] 90 - 119 days past due date"),
            new Option("4", "[4] 120 - 149 days past due date"),
            new Option("5", "[5] 150 - 179 days past due date"),
            new Option("6", "[6] 180 or more days past due date"),
            new Option("B", "[B] No payment history available prior to this time"),
            new Option("D", "[D] No payment history available this month"),
            new Option("E", "[E] Zero balance and current account"),
            new Option("G", "[G] Collection"),
            new Option("H", "[H] Foreclosure Completed"),
            new Option("J", "[J] Voluntary Surrender"),
            new Option("K", "[K] Repossession"),
            new Option("L", "[L] Charge-off")
        };

        public static List<Option> InterestTypeIndicator { get; } = new List<Option>() {
            new Option("F", "[F] Fixed"),
            new Option("V", "[V] Variable/Adjustable")
        };

        public static List<Option> State { get; } = new List<Option>() {
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

        public static List<Option> ResidenceCode { get; } = new List<Option>() {
            new Option("", ""),
            new Option("O", "[O] Owns"),
            new Option("R", "[R] Rents")
        };

        public static List<Option> AddressIndicator { get; } = new List<Option>() {
            new Option("", ""),
            new Option("C", "[C] Confirmed/Verified address"),
            new Option("Y", "[Y] Known to be address of primary consumer"),
            new Option("N", "[N] Not confirmed address"),
            new Option("M", "[M] Military address"),
            new Option("S", "[S] Secondary Address"),
            new Option("B", "[B] Business address — not consumer's residence"),
            new Option("U", "[U] Non-deliverable address/Returned mail"),
            new Option("D", "[D] Data reporter’s default address"),
            new Option("P", "[P] Bill Payer Service — not consumer’s residence")
        };
    }
}
