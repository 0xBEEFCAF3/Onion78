# MIT 2021 Bitcoin Hackathon
## Onion '78 - A Payjoin Implementation Over Tor

<p align="center">
  <img src="https://github.com/armins88/Onion78/raw/master/images/poster.jpg?raw=true" width="300"> 
</p>

## [🟠 Try Onion 78 PayJoin on TestFlight 👨🏻‍🔬](https://testflight.apple.com/join/Edhp2cXj)

## Resources
Presentation -  https://docs.google.com/presentation/d/1RWXk9A7V519o5C2rNhvrHW63b7Iz_Y7oVtujYxDTicI/edit?usp=sharing  
Figma PoC Mockup - https://www.figma.com/file/FM4jE85Aybr6fT00tyNhWc/Untitled?node-id=0%3A1  
Video Demo - https://www.youtube.com/watch?v=UsHOQIykfDo

## Team '78
@DanGould  
@armins88  
@johnsBeharry  
@ronaldstoner   

## Problem
Mobile bitcoin wallet applications are *NOT* private enough for both the *sender* as well as the *receiver*. A common-input-ownership heuristic exists which states that if a transaction has more than one input then all those inputs are owned by the same entity. This is one of the core heuristics used by chain analysis companies to determine the owner of specific unspent transaction outputs (UTXOs). UTXOs can be attributed ownership based on economic activity patterns, lack of privacy controls, and a false understanding of how UTXOs are processed in a bitcoin transaction.  

For those that wish to retain a higher level of privacy, solutions such as multisignature, CoinSwap, CoinJoin, and Payjoin exist -- but are not easily accessible to the common user, as most of these solutions require in-depth technical knowledge of the Bitcoin protocol and administration of infrastructure that can sync and store and maintain chain data. An additional knowledge set of how to construct, parse, and sign partially signed bitcoin transaction (PSBT) data is required for enhanced privacy features. Most end users without this level of technical acumen will fail at implementing the specification properly, and will ultimately sacrifice security and privacy of their funds and transactions for the sake of conveinence. 

## Onion '78 
Our project aims to implement the payjoin standard (BIP-78) and privacy features (Tor Hidden Services) into an existing mobile wallet application (Chaincase). A mobile wallet was selected due to it's ease of accessibility and portability, low cost profile for required hardware, and access to application distribution pipelines--providing a benefit to those who are attempting to remain as private as possible with as little footprint as possible, anywhere in the world. This software should be able to be executed and used on a variety of Apple iOS and Google Android devices.  

## Problems Faced
1. **Signing Coordination** - Transactions that require additional privacy tended to require lots of coordination between the transaction participants.

2. **Signer & Receiver Communication** - Transmitting this information in a private and secure manner has traditionally been a challenge for bitcoin transactions.  

3. **Transaction Confidentiality** - Out-of-band communications and broadcasting of data can be noisy and raise flags when one is trying to transact privately. 

4. **Hackathon Team [META]** - How can we work remotely as a team on the same project and meet our deliverables within 24 hours?

## Solution(s)
1. Onion '78
    - Sender and Receiver functionality 
    - Increased privacy controls
2. Tor Hidden Services
    - Removes the need for OOB channels
    - Private server hosting via mobile device (world to you)
    - Protects traffic of transaction sender and receiver
3. Payjoin
    - Many spends to one transaction
    - Extra data means more privacy
4. Project Management 
    - Lots of impromptu check-in calls
    - Scheduled status checks
    - Delegation of responsibilities
    - Knowing when to "call it" on a feature or enhancement 

## Technical Requirements / Goals
1. <span style="color:green">[DONE]</span> - Send and receive transactions according to the payjoin standard (BIP-78)
2. <span style="color:green">[DONE]</span> - Open a ephemeral Tor hidden service for every new PSBT negotiation phase
3. [STRETCH]<span style="color:red">[NOT_DONE]</span> - Alongside Tor also offer NFC as a form of offline communication between two parties

## Milestones
1. <span style="color:green">[DONE]</span> - Create and Destroy a Tor Hidden service reliably
2. <span style="color:green">[DONE]</span> - Implement both payjoin receiver and sender (PSBT logic, automatic coin selection, and fee estimations)
3. <span style="color:green">[DONE]</span> - Facilitate communication between receiver and sender (construct valid HTTP requests, listen for incoming requests via Tor, authentication of requests? )
4. <span style="color:green">[DONE]</span> - Create UI for both the payjoin receiver and sender
5. <span style="color:green">[DONE]</span> - Verify the validity of the final txn and broadcast
6. [STRETCH] Automate coin selection based on clustering for optimal privacy

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
