# MIT 2021 Bitcoin Hackathon
## Onion '78 - A Payjoin Implementation Over TOR

<p align="center">
  <img src="https://github.com/armins88/chaincase/raw/readme_update/images/poster.jpg?raw=true" width="300"> 
</p>

# Resources
TBD: Links, PDFs, video   
Presentation -   
Figma PoC Mockup - https://www.figma.com/file/FM4jE85Aybr6fT00tyNhWc/Untitled?node-id=0%3A1   
Video Demo -   

## Team '78
@DanGould  
@armins88  
@johnsBeharry  
@ronaldstoner   

## Problem
Mobile bitcoin wallet applications are *NOT* private enough for both the *sender* as well as the *receiver*. A common-input-ownership heuristic exists which states that if a transaction has more than one input then all those inputs are owned by the same entity. This is one of the core heuristics used by chain analysis companies to determine the owner of specific unspent transaction outputs (UTXOs). For those that wish to retain a higher level of privacy, solutions such as multisignature, CoinSwap, CoinJoin, and Payjoin exist but are not easily accessible to the common user, as most of these solutions require in-depth technical knowledge of the Bitcoin protocol and administration of infrastructure that can sync and maintain chain data. An additional knowledge set of how to construct, parse, and sign partially signed bitcoin transaction (PSBT) data is required for enhanced privacy features. 

## Solution 
Our project aims to implement the payjoin standard (BIP-78) and privacy features (TOR Hidden Services) into an existing mobile wallet application (Chaincase). A mobile wallet was selected due to it's ease of accessability and portability, providing a benefit to those who are attempting to remain as private as possible with as little footprint as possible, anywhere in the world. This software should be able to be be executed and used on a variety of Apple iOS and Google Android devices.  

## Problems Faced
1. **Signing Coordination** - Transactions that require additional privacy tended to require lots of cooridnation between the transaction participants. 

2. **Signer & Receiver Communication** - Transmitting this information in a private and secure manner has traditionally been a challenge for bitcoin transactions.  

3. **Transaction Confidentiality** - Out of band communications and broadcasting of data can be noisy and raise flags when once is trying to transact privately. 

4. **Hackathon Team [META]** - How can we work remotely as a team on the same project and meet our deliverabiles within 24 hours?

## Solution(s)
1. Onion '78
    - Sender and Receiver functionality 
2. TOR Hidden Services
    - Removes the need for OOB channels
3. Payjoin
    - Many spends to one transaction
    - Extra data means more privacy
4. Project Management 
    - Lots of impromptu check-in calls
    - Scheduled status checks
    - Delegation of responsibilities
    - Knowing when to "call it" on a feature or enhancement 

## Technical Requirements / Milestones
1. <span style="color:green">[DONE]</span> - Send and receive transactions according to the payjoin standard (BIP78)
2. <span style="color:green">[DONE]</span> - Open a ephemeral tor hidden service for every new PSBT negotiation phase
3. [STRETCH]<span style="color:red">[NOT_DONE]</span> - Alongside Tor also offer NFC as a form of offline communication between two parties

## Mobile Wallet - Chaincase
A non-custodial iOS bitcoin wallet supporting [Chaumian CoinJoin](https://github.com/nopara73/ZeroLink/#ii-chaumian-coinjoin).

## Building for iOS

make sure to have the Wasabi submodule installed:
```console
git submodule update --init --recursive
```

pull the Tor binary:
```console
git lfs pull
```
Install a provisioning profile to make use of the entitlements:
https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/
